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
    /// Interaction logic for AddressWindow.xaml
    /// </summary>
    public partial class AddressWindow : Window
    {
        UserAddress address;
        List<State> states;
        Guid userId;

        // For New Address
        public AddressWindow(Guid userid)
        {
            userId = userid;
            InitializeComponent();
        }

        // For Existing Address
        public AddressWindow(Guid addressid, Guid userid)
        {
            address = UserAddressManager.LoadByUserAndAddressId(addressid, userid);

            InitializeComponent();

            txtAddress.Text = address.Address;
            txtCity.Text = address.City;

            Reload();
            cboState.DisplayMemberPath = "Name";
            cboState.SelectedValuePath = "Id";

            cboState.SelectedItem = address.State;

            txtZip.Text = address.ZipCode;

        }

        // Reloads states combobox
        private void Reload()
        {
            cboState.ItemsSource = null;
            states = UserAddressManager.LoadStates();
            cboState.ItemsSource = states;
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtAddress.Text != "" &&
                txtCity.Text != "" &&
                txtZip.Text != "")
            {
                address = new UserAddress()
                {
                    Id = Guid.Empty,
                    UserId = userId,
                    Address = txtAddress.Text,
                    City = txtCity.Text,
                    State = "WI",
                    ZipCode = txtZip.Text,
                };

                bool result = UserAddressManager.Insert(address);

                if (result)
                {
                    MessageBox.Show("Address added.");
                    this.Close();
                }
                else
                    MessageBox.Show("An error occurred when inserting.");
            }
            else
                MessageBox.Show("Error. Please enter data into the fields.");
        }
        private void btnUpdate_Click(object sender,  RoutedEventArgs e)
        {
            if (txtAddress.Text != "" &&
                txtCity.Text != "" &&
                txtZip.Text != "")
            {
                address.Address = txtAddress.Text;
                address.City = txtCity.Text;
                address.ZipCode = txtZip.Text;

                int result = UserAddressManager.Update(address);
                
                if (result >= 1)
                {
                    MessageBox.Show("Address updated.");
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
            int result = UserAddressManager.Delete(address.Id);
            
            if (result >= 1)
            {
                MessageBox.Show("Address deleted.");
                this.Close();
            }
            else
                MessageBox.Show("An error occurred when deleting.");
        }
    }
}
