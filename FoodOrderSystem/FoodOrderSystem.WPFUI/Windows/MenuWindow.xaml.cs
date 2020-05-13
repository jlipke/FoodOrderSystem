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

namespace FoodOrderSystem.WPF
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        Guid UserId;

        public MenuWindow(Guid userId)
        {
            UserId = userId;
            InitializeComponent();

            DrawScreen();
        }

        public void DrawScreen()
        {
            ucNavigation navigation = new ucNavigation(UserId);
            navigation.Margin = new Thickness(0, 0, 0, 0);
            grdMenuScreen.Children.Add(navigation);
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (UserId != Guid.Empty)
            {

            }
            else
            {
                MessageBox.Show("Please login to add items to cart");
            }
        }
    }
}
