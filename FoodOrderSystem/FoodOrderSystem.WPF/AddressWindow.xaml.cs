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
    /// Interaction logic for AddressWindow.xaml
    /// </summary>
    public partial class AddressWindow : Window
    {
        UserAddress address;

        public AddressWindow()
        {
            address = new UserAddress();
            InitializeComponent();
        }
        public AddressWindow(Guid addressid)
        {
            address = UserAddressManager.LoadById(addressid);

            InitializeComponent();

            txtAddress.Text = address.Address;
            txtCity.Text = address.City;
            txtZip.Text = address.ZipCode;

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                address = new UserAddress()
                {
                    Id = Guid.Empty,
                    Address = txtAddress.Text,
                    City = txtCity.Text,
                    State = "WI",
                    ZipCode = txtZip.Text,
                };

                bool result = UserAddressManager.Insert(address);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnUpdate_Click(object sender,  RoutedEventArgs e)
        {
            try
            {
                address.Address = txtAddress.Text;
                address.City = txtCity.Text;
                address.ZipCode = txtZip.Text;

                int result = UserAddressManager.Update(address);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = UserAddressManager.Delete(address.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
