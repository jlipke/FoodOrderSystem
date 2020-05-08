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
using FoodOrderSystem.API;
using FoodOrderSystem.BL;
using FoodOrderSystem.BL.Models;

namespace FoodOrderSystem.UserControls
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

        }
    }
}
