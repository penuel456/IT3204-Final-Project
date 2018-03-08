using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Documents;

namespace JGP_INVENTORY.Model
{
    public class ProductData
    {
        public String prod_name { get; set; }
        public int prod_qty { get; set; }
        public int prod_price { get; set; }
    } 

    class CRUDProduct
    {
        MySqlConnection conn = new
        MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        String query;
        String query2;

        public String AddProduct(String prod_name, int prod_qty, int prod_price)
        {
            string text;

            if (string.IsNullOrEmpty(prod_name) || prod_qty == 0 || prod_price == 0)
            {
                text = "Please don't leave any of the text fields empty.";
                return text;
            }
            else
            {
                query = "INSERT INTO product (prod_name, prod_qty, prod_price, prod_id) VALUES ('" + prod_name + "', '" + prod_qty + "', '" + prod_price + "', NULL)";
                query2 = "SELECT COUNT(*) FROM product WHERE prod_name = '" + prod_name + "' ";
                conn.Open();
                MySqlCommand cmdcheck = new MySqlCommand(query2, conn);
                cmdcheck.CommandType = CommandType.Text;
                int count = Convert.ToInt32(cmdcheck.ExecuteScalar());
                if (count == 0)
                {

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    text = "Successfully added the product into the inventory.";
                    return text;
                }
                else
                {
                    text = "Record already exists.";
                    conn.Close();
                    return text;
                }


            }
        }

        public List<ProductData> GetProductData(int prod_id)
        {
            var data = new List<ProductData>();
            conn.Open();
            query  = "SELECT COUNT(*) FROM product WHERE prod_id = " + prod_id;

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            if(Convert.ToInt32(cmd.ExecuteScalar()) > 0)
            {
                query = "SELECT prod_name, prod_qty, prod_price FROM product WHERE prod_id = " + prod_id;

                cmd = new MySqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(new ProductData
                        {
                            prod_name = reader.GetString(0),
                            prod_qty = reader.GetInt32(1),
                            prod_price = reader.GetInt32(2)
                        });
                    }
                }
            }
            else
            {
                data.Add(new ProductData
                {
                    prod_name = "Data not found.",
                    prod_qty = 0,
                    prod_price = 0
                });
            }

            conn.Close();
            return data;
        }

        public void EditProduct(int prod_id, String prod_name, String prod_qty, String prod_price)
        {
            query = "UPDATE product SET prod_name = '"+prod_name+"', prod_qty = "+prod_qty+", prod_price = "+prod_price+" WHERE prod_id = "+prod_id;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteProduct(String prod_name)
        {
            query = "DELETE FROM product WHERE prod_name = '" + prod_name + "'";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public DataSet SearchProduct(String prod_name)
        {
            query = "SELECT * FROM product WHERE prod_name LIKE '%" + prod_name + "%'";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "LoadDataBinding");
            conn.Close();
            return ds;
        }
        public DataSet DisplayProduct()
        {
            query = "SELECT * FROM product";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "LoadDataBinding");
            conn.Close(); 
            
            return ds;
        }
        public String Register(String User, String Password, String ConfirmPass)
        {
            String text;
            if (User.Length == 0)
            {
                text = "Enter a username.";
                return text;
                //textBoxEmail.Focus();
            }
            /* else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
             {
                 errormessage.Text = "Enter a valid email.";
                 textBoxEmail.Select(0, textBoxEmail.Text.Length);
                 textBoxEmail.Focus();
             }*/
            else
            {
                //  string firstname = textBoxFirstName.Text;
                //  string lastname = textBoxLastName.Text;
                string email = User;
                string password = Password;
                if (Password.Length == 0)
                {
                    text = "Enter password.";
                    return text;
                    // passwordBox1.Focus();
                }
                else if (ConfirmPass.Length == 0)
                {
                    text = "Enter Confirm password.";
                    return text;
                    //  passwordBoxConfirm.Focus();
                }
                else if (Password != ConfirmPass)
                {
                    text = "Confirm password must be same as password.";
                    return text;
                    // ConfirmPass.Focus();
                }
                else
                {
                    text = "";
                    // string address = textBoxAddress.Text;
                    // SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
                    query = "INSERT INTO users (Username,Password) VALUES('" + email + "','" + password + "')";
                    conn.Open();

                    // Call the function from the View Model, then the View Model will call the 
                    // Model to execute these codes below and return the results here



                    /*
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM product", conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds, "LoadDataBinding");
                    dataGridCustomers.DataContext = ds;
                    */
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    text = "You have Registered successfully.";

                    //  Reset();
                    return text;
                }
            }
        }
        public String Login(String User, String Pass)
        {
            String Text;
            if (User.Length == 0)
            {
                Text = "Enter your username.";
                //textBoxEmail.Focus();
            }
            else
            {
                string email = User;
                string password = Pass;
                // SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
                query = "SELECT * FROM users WHERE username='" + email + "'  AND password='" + password + "'";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
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
                    Text = username;
                }
                else
                {
                    Text = "Sorry! Please enter existing username/password.";
                }
                conn.Close();

            }
            return Text;
        }
    }
}
