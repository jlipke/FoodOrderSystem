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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodOrderSystem.WPF
{
    /// <summary>
    /// Interaction logic for ucNavigation.xaml
    /// </summary>
    public partial class ucNavigation : UserControl
    {
        public static Guid UserId;

        public ucNavigation(Guid userid)
        {
            if (userid != Guid.Empty)
                UserId = userid;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            new HomeWindow(UserId).ShowDialog();
        }
        
        private void btnMenuItem_Click(object sender, RoutedEventArgs e)
        {
            new MenuWindow(UserId).ShowDialog();
        }

        private void btnShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            if (UserId != Guid.Empty)
                new ShoppingWindow(UserId).ShowDialog();
            else
                MessageBox.Show("Please login for to look at your cart.");
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            if (UserId != Guid.Empty)
                new AccountWindow(UserId).ShowDialog();
            else
                new LoginWindow().ShowDialog();
        }
    }
}
