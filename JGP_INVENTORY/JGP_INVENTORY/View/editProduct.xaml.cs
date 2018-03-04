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

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if(prod_id.Text != null && prod_name.Text != null && prod_qty != null && prod_price != null)
            {
                vm.CallEditProduct(int.Parse(prod_id.Text), prod_name.Text, prod_qty.Text, prod_price.Text);
                Hide();
            }
        }
    }
}
