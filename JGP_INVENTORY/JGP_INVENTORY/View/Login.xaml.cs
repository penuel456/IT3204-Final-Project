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
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Configuration;
using JGP_INVENTORY.ViewModel;



namespace JGP_INVENTORY.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 

    public partial class Login : Window
    {
        MySqlConnection conn = new
       MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        ProductViewModel vm = new ProductViewModel();
      //  Page1 page = new Page1();

        public Login()
        {
            InitializeComponent();
        }
        Registration registration = new Registration();
        Welcome welcome = new Welcome();
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
            //Close();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            /*if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else
            {
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
               // SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from users where username='" + email + "'  and password='" + password + "'", conn);
                cmd.CommandType = CommandType.Text;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string username = dataSet.Tables[0].Rows[0]["Username"].ToString();
                    // page.Welcome(username);//Sending value from one form to another form.
                    //page.Welcome.Content = username;
                    welcome.Name.Content = username;
                    welcome.Show();
                    Close();
                }
                else
                {
                    errormessage.Text = "Sorry! Please enter existing username/password.";
                }
                conn.Close();
            }*/
            String text = vm.CallLogin(textBoxEmail.Text, passwordBox1.Password);
            if(text == "Enter your username.")
            {
                errormessage.Text = text;
            }else if(text == "Sorry! Please enter existing username/password.")
            {
                errormessage.Text = text;
            }
            else
            {
                welcome.Label.Content = text;
                welcome.Show();
                Close();
            }
        
        }

      

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}