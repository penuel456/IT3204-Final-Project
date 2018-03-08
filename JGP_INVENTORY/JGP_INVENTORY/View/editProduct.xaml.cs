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

        ProductViewModel vm = new ProductViewModel();

        private void clearContents()
        {
            prod_id.Text = "";
            prod_name.Text = "";
            prod_qty.Text = "";
            prod_price.Text = "";
            notif.Text = "";
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if(prod_id.Text.ToString() != "" && prod_name.Text.ToString() != "" && prod_price.Text.ToString() != "" && prod_qty.Text.ToString() != "")
            {
                vm.CallEditProduct(int.Parse(prod_id.Text), prod_name.Text, prod_qty.Text, prod_price.Text);
                clearContents();
                Hide();
            }
            else
            {
                notif.Text = "Please don't leave any fields empty.";
            }
        }

        private void getDataBtn_Click(object sender, RoutedEventArgs e)
        {
            if(prod_id.Text.ToString() != "")
            {
                var data = new List<ProductData>();

                data = vm.CallGetProductData(Convert.ToInt32(prod_id.Text.ToString()));

                prod_name.Text = Convert.ToString(data.ElementAt(0).prod_name);
                prod_qty.Text = Convert.ToString(data.ElementAt(0).prod_qty);
                prod_price.Text = Convert.ToString(data.ElementAt(0).prod_price);

                notif.Text = "Product Data retrieved";
            }
            else
            {
                notif.Text = "Please input an ID";
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            clearContents();

            Hide();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            clearContents();
        }
    }
}
