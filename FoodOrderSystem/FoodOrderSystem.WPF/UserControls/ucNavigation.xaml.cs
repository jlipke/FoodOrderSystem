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
        public static Guid UserAuthentication { get; set; }

        public ucNavigation()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void btnMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShoppingCart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            if (UserAuthentication != Guid.Empty)
                new AccountWindow(UserAuthentication).ShowDialog();
            else
                new LoginWindow().ShowDialog();
        }
    }
}
