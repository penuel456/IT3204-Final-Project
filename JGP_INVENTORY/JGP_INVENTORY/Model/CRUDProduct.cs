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

namespace JGP_INVENTORY.Model
{
    class CRUDProduct
    {
        MySqlConnection conn = new
        MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public void AddProduct(String prod_name, int prod_qty, int prod_price)
        {
            //SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO product (prod_name, prod_qty, prod_price, prod_id) VALUES ('"+prod_name+"', '"+prod_qty+"', '"+prod_price+"', NULL)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void EditProduct(String prod_name, int prod_qty, String prod_price, int prod_id)
        {
            SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE product SET prod_name = "+prod_name+", prod_qty = "+prod_qty+" , prod_price = "+prod_price+" WHERE prod_id = "+prod_id , con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteProduct(String prod_name)
        {
           // SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM product WHERE prod_name = '" +prod_name+"'", conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public DataSet SearchProduct(String prod_name)
        {
            /*
            SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM product WHERE prod_name = "+prod_name, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            */

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM product WHERE prod_name LIKE '%"+prod_name+"%'", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "LoadDataBinding");
            conn.Close();
            return ds;
        }
        public DataSet DisplayProduct()
        {
            /*
            SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM product", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            */

            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM product", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "LoadDataBinding");
            conn.Close(); 
            
            return ds;
        }
    }
}
