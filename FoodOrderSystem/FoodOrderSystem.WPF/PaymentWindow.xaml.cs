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
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        UserPayment payment;

        public PaymentWindow()
        {
            payment = new UserPayment();

            InitializeComponent();
        }
        public PaymentWindow(Guid paymentid)
        {
            payment = UserPaymentManager.LoadById(paymentid);

            InitializeComponent();

            txtCardHolderName.Text = payment.CardHolderName;
            txtCardNumber.Text = payment.CardNumber;
            txtExpirationDate.Text = payment.ExpirationDate;
            txtCVC.Text = payment.CVC;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
