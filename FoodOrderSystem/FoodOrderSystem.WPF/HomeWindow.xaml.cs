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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        Guid userid;

        public HomeWindow()
        {
            userid = Guid.Empty;
            InitializeComponent();
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            if (userid != Guid.Empty)
            {
                new AccountWindow(userid).ShowDialog();
            }
            else
            {
                new LoginWindow().ShowDialog();
            }
        }
    }
}
