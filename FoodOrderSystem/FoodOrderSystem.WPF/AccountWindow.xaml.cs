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
        Guid userid;
        public AccountWindow()
        {
            List<User> users = UserManager.Load();
            User user = users.FirstOrDefault(u => u.Email == "lewandowski.william@gmail.com");
            userid = user.Id;

            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtPhone.Text = user.Phone;
            lblEmailShow.Content = user.Email;
            txtPassword.Text = user.Password;
            InitializeComponent();
        }
        public AccountWindow(Guid accountid)
        {
            User user = UserManager.LoadById(accountid);
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtPhone.Text = user.Phone;
            lblEmailShow.Content = user.Email;
            txtPassword.Text = user.Password;

            userid = accountid;

            InitializeComponent();
        }

        private void RefreshScreen()
        {
            dgvAddressInfo.ItemsSource = null;
            dgvPaymentInfo.ItemsSource = null;

            dgvAddressInfo.ItemsSource = addresses;
            dgvPaymentInfo.ItemsSource = payments;
        }

        private void RefreshAddressScreen()
        {
            dgvAddressInfo.ItemsSource = null;
            dgvAddressInfo.ItemsSource = addresses;
        }
        private void RefreshPaymentScreen()
        {
            dgvPaymentInfo.ItemsSource = null;
            dgvPaymentInfo.ItemsSource = payments;
        }

        private void btnLoadAddress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addresses = UserAddressManager.LoadByUserId(userid);
                payments = UserPaymentManager.LoadByUserId(userid);
                RefreshScreen();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnAddAddress_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEditAddress_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeleteAddress_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
