using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FoodOrderSystem.BL;
using FoodOrderSystem.BL.Models;

namespace FoodOrderSystem.WPF
{
    /// <summary>
    /// Interaction logic for ShoppingWindow.xaml
    /// </summary>
    public partial class ShoppingWindow : Window
    {
        private List<BL.Models.MenuItem> ShoppingCart;
        private List<UserAddress> addresses;
        private List<UserPayment> payments;
        private Order order;
        public Guid userId;
        public ShoppingWindow(List<BL.Models.MenuItem> shoppingCart, Guid userid)
        {
            InitializeComponent();
            ShoppingCart = shoppingCart;
            userId = userid;
            Reload();

            cboAddress.DisplayMemberPath = "Address";
            cboAddress.SelectedValuePath = "Id";

            cboPayment.DisplayMemberPath = "CardNumber";
            cboPayment.SelectedValuePath = "Id";
        }
        private void Reload()
        {
            dgvCart.ItemsSource = null;
            cboAddress.ItemsSource = null;
            cboPayment.ItemsSource = null;

            addresses = UserAddressManager.LoadByUserId(userId);
            payments = UserPaymentManager.LoadByUserId(userId);

            dgvCart.ItemsSource = ShoppingCart;
            cboAddress.ItemsSource = addresses;
            cboPayment.ItemsSource = payments;
        }
        private void DrawScreen()
        {
            ucNavigation navigation = new ucNavigation(userId);
            navigation.Margin = new Thickness(0, 0, 0, 0);
            grdShoppingScreen.Children.Add(navigation);
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            bool completed = false;

            order = new Order
            {
                Id = Guid.Empty,
                UserId = userId,
                AddressId = addresses[cboAddress.SelectedIndex].Id,
                PaymentId = payments[cboPayment.SelectedIndex].Id,
                Date = DateTime.Now
            };

            bool result = OrderManager.Insert(order);

            if (result)
            {
                OrderItem item;

                for (int i = 0; i < ShoppingCart.Count; i++)
                {
                    item = new OrderItem
                    {
                        Id = Guid.Empty,
                        OrderId = order.Id,
                        MenuItemId = ShoppingCart[i].Id
                    };

                    bool iteminsertresult = OrderItemManager.Insert(item);
                    if (!iteminsertresult)
                    {
                        OrderManager.Delete(order.Id);
                        MessageBox.Show("An error Occurred. Order not completed");
                        completed = false;
                        break;
                    }
                    else
                    {
                        completed = true;
                    }
                }

                if (completed)
                {
                    MessageBox.Show("Order Completed. Thank you for your purchase.");
                    this.Close();
                }
            }
            else
                MessageBox.Show("An error occurred while creating your order.");

        }
    }
}
