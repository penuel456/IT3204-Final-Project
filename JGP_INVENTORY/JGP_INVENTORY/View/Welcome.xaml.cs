






























































using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JGP_INVENTORY.View
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
           
        }

        private void logout_Btn1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page1();
        }

        private void View_Prod(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page2();
        }
    }
}
