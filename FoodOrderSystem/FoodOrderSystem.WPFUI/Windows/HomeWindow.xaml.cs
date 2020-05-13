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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public Guid UserId;

        public HomeWindow()
        {
            InitializeComponent();

            UserId = Guid.Empty;

            DrawScreen();
        }
        private void DrawScreen()
        {
            ucNavigation navigation = new ucNavigation(UserId);
            navigation.Margin = new Thickness(0, 0, 0, 0);
            grdHomeScreen.Children.Add(navigation);
        }
    }
}
