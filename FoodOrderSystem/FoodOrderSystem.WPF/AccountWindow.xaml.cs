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
using FoodOrderSystem.API;
using FoodOrderSystem.BL;
using FoodOrderSystem.BL.Models;
using FoodOrderSystem.UserControls;

namespace FoodOrderSystem.WPF
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        List<UserAddress> addresses;
        List<UserPayment> payments;
        User user;
        public AccountWindow()
        {

            List<User> users = UserManager.Load();
            user = users.FirstOrDefault(u => u.Email == "lewandowski.william@gmail.com");

            InitializeComponent();

            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtPhone.Text = user.Phone;
            lblEmailShow.Content = user.Email;
            txtPassword.Text = user.Password;
        }
        public AccountWindow(Guid userid)
        {
            user = UserManager.LoadById(userid);
            
            InitializeComponent();

            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtPhone.Text = user.Phone;
            lblEmailShow.Content = user.Email;
            txtPassword.Text = user.Password;
        }

        private void RefreshScreen()
        {
            dgvAddressInfo.ItemsSource = null;
            dgvPaymentInfo.ItemsSource = null;

            dgvAddressInfo.ItemsSource = addresses;
            dgvPaymentInfo.ItemsSource = payments;

            dgvAddressInfo.Columns[0].Visibility = Visibility.Hidden;
            dgvAddressInfo.Columns[1].Visibility = Visibility.Hidden;
            dgvAddressInfo.Columns[2].Header = "Address";
            dgvAddressInfo.Columns[3].Header = "City";
            dgvAddressInfo.Columns[4].Header = "State";
            dgvAddressInfo.Columns[5].Header = "Zip";

            dgvPaymentInfo.Columns[0].Visibility = Visibility.Hidden;
            dgvPaymentInfo.Columns[1].Visibility = Visibility.Hidden;
            dgvPaymentInfo.Columns[2].Header = "Card Holder";
            dgvPaymentInfo.Columns[3].Header = "Card Number";
            dgvPaymentInfo.Columns[4].Header = "Expiration Date";
            dgvPaymentInfo.Columns[5].Header = "CVC";
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addresses = UserAddressManager.LoadByUserId(user.Id);
                payments = UserPaymentManager.LoadByUserId(user.Id);
                RefreshScreen();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgvAddressInfo.SelectedIndex > -1)
            {
                new AddressWindow(addresses[dgvAddressInfo.SelectedIndex].Id).ShowDialog();
                RefreshScreen();
            }
            else if (dgvPaymentInfo.SelectedIndex > -1)
            {
                new PaymentWindow(payments[dgvPaymentInfo.SelectedIndex].Id).ShowDialog();
                RefreshScreen();
            }
            else
            {
                MessageBox.Show("Please select either an address or payment to edit...");
            }
        }
    }
}
