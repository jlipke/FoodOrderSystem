﻿using System;
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

namespace FoodOrderSystem.WPF
{
    /// <summary>
    /// Interaction logic for CreateAccountWindow.xaml
    /// </summary>
    public partial class CreateAccountWindow : Window
    {
        public CreateAccountWindow()
        {
            InitializeComponent();
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                Id = Guid.Empty,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Password = txtPassword.Text
            };

            int result = UserManager.Insert(user);

            if (result >= 0)
            {
                UserPayment payment = new UserPayment()
                { 
                    Id = Guid.Empty,
                    UserId = user.Id,
                    CardHolderName = txtCardHolderName.Text,
                    CardNumber = txtCardNumber.Text,
                    ExpirationDate = txtExpirationDate.Text,
                    CVC = txtCVC.Text
                };

                UserAddress address = new UserAddress()
                {
                    Id = Guid.Empty,
                    UserId = user.Id,
                    Address = txtAddress.Text,
                    City = txtCity.Text,
                    State = cboState.DisplayMemberPath,
                    ZipCode = txtZip.Text
                };

                bool paymentresult = UserPaymentManager.Insert(payment);
                bool addressresult = UserAddressManager.Insert(address);

                if (paymentresult && addressresult)
                {
                    this.Close();
                    new LoginWindow().ShowDialog();
                }
                else
                    MessageBox.Show("An Error Occurred. Invaild Data Entered for Address or Payment");
            }
            else
                MessageBox.Show("An Error Occurred. Invalid Data Entered for User.");
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}