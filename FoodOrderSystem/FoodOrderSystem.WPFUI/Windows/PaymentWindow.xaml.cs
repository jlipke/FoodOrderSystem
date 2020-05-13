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

namespace FoodOrderSystem.WPF
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        UserPayment payment;
        Guid userId;

        public PaymentWindow(Guid userid)
        {
            userId = userid;
            InitializeComponent();
        }
        public PaymentWindow(Guid paymentid, Guid userid)
        {
            payment = UserPaymentManager.LoadByUserAndPaymentId(paymentid, userid);

            InitializeComponent();

            txtCardHolderName.Text = payment.CardHolderName;
            txtCardNumber.Text = payment.CardNumber;
            txtExpirationDate.Text = payment.ExpirationDate;
            txtCVC.Text = payment.CVC;
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtCardHolderName.Text != "" &&
                txtCardNumber.Text != "" &&
                txtExpirationDate.Text != "" &&
                txtCVC.Text != "")
            {
                payment = new UserPayment()
                {
                    Id = Guid.Empty,
                    UserId = userId,
                    CardHolderName = txtCardHolderName.Text,
                    CardNumber = txtCardNumber.Text,
                    ExpirationDate = txtExpirationDate.Text,
                    CVC = txtCVC.Text
                };

                bool result = UserPaymentManager.Insert(payment);

                if (result)
                {
                    MessageBox.Show("Payment saved.");
                    this.Close();
                }
                else
                    MessageBox.Show("An error occurred when inserting.");
            }
            else
                MessageBox.Show("Error. Please enter data into the fields.");
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtCardHolderName.Text != "" &&
                txtCardNumber.Text != "" &&
                txtExpirationDate.Text != "" &&
                txtCVC.Text != "")
            {
                payment.CardHolderName = txtCardHolderName.Text;
                payment.CardNumber = txtCardNumber.Text;
                payment.ExpirationDate = txtExpirationDate.Text;
                payment.CVC = txtCVC.Text;

                int result = UserPaymentManager.Update(payment);

                if (result >= 1)
                {
                    MessageBox.Show("Payment updated.");
                    this.Close();
                }
                else
                    MessageBox.Show("An error occurred when updating.");
            }
            else
                MessageBox.Show("Error. Please enter data into the fields.");
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int result = UserPaymentManager.Delete(payment.Id);

            if (result >= 1)
            {
                MessageBox.Show("Payment deleted.");
                this.Close();
            }
            else
                MessageBox.Show("An error occurred when deleting.");
        }
    }
}
