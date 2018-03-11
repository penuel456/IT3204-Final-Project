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
using JGP_INVENTORY.ViewModel;
using JGP_INVENTORY.Model;


namespace JGP_INVENTORY.View
{
    /// <summary>
    /// Interaction logic for editProduct.xaml
    /// </summary>
    public partial class editProduct : Window
    {
        public editProduct()
        {
            InitializeComponent();
        }
        private void clearContents()
        {
            prod_id.Text = "";
            prod_name.Text = "";
            prod_qty.Text = "";
            prod_price.Text = "";
        }
        ProductViewModel vm = new ProductViewModel();

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if(prod_id.Text != null && prod_name.Text != null && prod_qty != null && prod_price != null)
            {
                vm.CallEditProduct(int.Parse(prod_id.Text), prod_name.Text, prod_qty.Text, prod_price.Text);
                Hide();
            }
        }
        private void getDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if (prod_id.Text.ToString() != "")
            {
                var data = new List<ProductData>();

                data = vm.CallGetProductData(Convert.ToInt32(prod_id.Text.ToString()));

                prod_name.Text = Convert.ToString(data.ElementAt(0).prod_name);
                prod_qty.Text = Convert.ToString(data.ElementAt(0).prod_qty);
                prod_price.Text = Convert.ToString(data.ElementAt(0).prod_price);
            }

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clearContents();
            Hide();
        }

        private void getDataBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
