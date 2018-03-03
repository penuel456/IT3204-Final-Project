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

        public void AddProduct(String prod_name, int prod_qty, String prod_price, int prod_id)
        {
            SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO product (prod_name, prod_qty, prod_price, prod_id) VALUES ('"+prod_name+"', '"+prod_qty+"', '"+prod_price+"', NULL)", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
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
        public void DeleteProduct(int prod_id)
        {
            SqlConnection con = new SqlConnection("Data Source=TESTPURU;Initial Catalog=Data;User ID=sa;Password=wintellect");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM product WHERE prod_id = " + prod_id, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
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
