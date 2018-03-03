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
using System.Data;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Configuration;
using JGP_INVENTORY.ViewModel;

namespace JGP_INVENTORY.View
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        MySqlConnection conn = new
        MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        ProductViewModel vm = new ProductViewModel();

        public Registration()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            //textBoxFirstName.Text = "";
           // textBoxLastName.Text = "";
            textBoxEmail.Text = "";
          //  textBoxAddress.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            String text;
           text = vm.CallRegister(textBoxEmail.Text, passwordBox1.Password, passwordBoxConfirm.Password);
            if(text == "Enter a username.")
            {
                textBoxEmail.Focus();
            }else if(text == "Enter password.")
            {
                passwordBox1.Focus();
            }else if(text == "Enter Confirm password")
            {
                passwordBoxConfirm.Focus();
            }else if (text == "Confirm password must be same as password.")
            {
                passwordBoxConfirm.Focus();
            }else if(text == "")
            {
                Reset();
            }
            errormessage.Text = text;
            }
        }
    }
