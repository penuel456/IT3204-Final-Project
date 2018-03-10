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
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using JGP_INVENTORY.ViewModel;
using System.Configuration;

namespace JGP_INVENTORY.View
{
    /// <summary>
    /// Interaction logic for addProduct.xaml
    /// </summary>
    public partial class addProduct : Window
    {
        public addProduct()
        {
            InitializeComponent();
        }
        ProductViewModel vm = new ProductViewModel();
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {

            prodName.Text = "";
            prodQty.Text = "0";
            prodPrice.Text = "0";

            Hide();
        }
        

        private void insertBtn_Click_1(object sender, RoutedEventArgs e)
        {
            string text;
            text = vm.CallAddProduct(prodName.Text, Int32.Parse(prodQty.Text), Int32.Parse(prodPrice.Text));

            notif.Text = text;

            prodName.Text = "";
            prodQty.Text = "0";
            prodPrice.Text = "0";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
