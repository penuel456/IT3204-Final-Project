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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using JGP_INVENTORY.ViewModel;

namespace JGP_INVENTORY.View
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        // MySqlConnection Connection
        MySqlConnection conn = new
        MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        ProductViewModel vm = new ProductViewModel();
        addProduct addprod = new addProduct();
        editProduct editprod = new editProduct();
        DeleteProduct delprod = new DeleteProduct();

        public Page1(String test)
        {
            InitializeComponent();
            Welcome_Label.Content = test;
        }

        private void btnloaddata_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Call the function from the View Model, then the View Model will call the 
                // Model to execute these codes below and return the results here

                dataGridCustomers.DataContext = vm.CallDisplayProdinNeed();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        

      

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //addprod.Show();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            addprod.Show();
        }

        /*private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
           
        }*/
    }
}
