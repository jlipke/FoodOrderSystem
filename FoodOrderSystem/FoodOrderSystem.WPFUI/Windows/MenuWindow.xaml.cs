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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        Guid UserId;
        List<BL.Models.MenuItem> menuItems;
        List<BL.Models.MenuItem> OrderItems;

        public MenuWindow(Guid userId)
        {
            UserId = userId;
            InitializeComponent();
            OrderItems = new List<BL.Models.MenuItem>();

            Reload();

            DrawScreen();
        }

        private void Reload()
        {
            dgvMenu.ItemsSource = null;
            menuItems = MenuItemManager.Load();
            dgvMenu.ItemsSource = menuItems;
        }
        private void DrawScreen()
        {
            ucNavigation navigation = new ucNavigation(UserId);
            navigation.Margin = new Thickness(0, 0, 0, 0);
            grdMenuScreen.Children.Add(navigation);
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (UserId != Guid.Empty)
            {
                if (dgvMenu.SelectedIndex > -1)
                {
                    OrderItems.Add(menuItems[dgvMenu.SelectedIndex]);
                    MessageBox.Show("Item added to cart.");
                }
                else
                {
                    MessageBox.Show("Please select a menu item.");
                }
            }
            else
            {
                MessageBox.Show("Please login to add items to cart");
            }
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            new ShoppingWindow(OrderItems, UserId).ShowDialog();
        }
    }
}
