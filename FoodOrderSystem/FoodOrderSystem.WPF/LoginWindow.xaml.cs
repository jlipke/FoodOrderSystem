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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Guid id;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text != "" && txtPassword.Text != "")
            {
                int result = UserManager.Login(txtEmail.Text, txtPassword.Text, out id);

                if (result >= 1)
                {
                    this.Close();
                    new AccountWindow(id).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid email or password.");
                    HomeWindow.UserAuthentication = Guid.Empty;
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                }
            }
            else
                MessageBox.Show("Please enter data into the fields.");
        }
    }
}
