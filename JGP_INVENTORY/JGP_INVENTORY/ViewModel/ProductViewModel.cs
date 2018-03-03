﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JGP_INVENTORY.Model;

namespace JGP_INVENTORY.ViewModel
{


    class ProductViewModel
    {
        CRUDProduct crud = new CRUDProduct();

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        public void CallAddProduct(String prod_name, int prod_qty, int prod_price)
        {
            crud.AddProduct(prod_name, prod_qty, prod_price);
        }

        public void CallEditProduct(String prod_name, int prod_qty, String prod_price, int prod_id)
        {
            if (IsTextAllowed(prod_price))
            {
                crud.EditProduct(prod_name, prod_qty, prod_price, prod_id);
            }
        }

        public void CallDeleteProduct(String prod_name)
        {
            crud.DeleteProduct(prod_name);
        }
        public DataSet CallSearchProduct(String prod_name)
        {
            return crud.SearchProduct(prod_name);
        }
        public DataSet CallDisplayProduct()
        {
            return crud.DisplayProduct();
        }
        public String CallRegister(String user, String Pass, String ConfirmPass)
        {
            return crud.Register(user, Pass, ConfirmPass);
        }
        public String CallLogin(String User, String Pass)
        {
            return crud.Login(User, Pass);
        }
    }
}
