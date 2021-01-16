using ONLINE_SALES_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Services
{
    class MenuServices
    {
        public MenuProduct menuProduct { get; set; }

        public MenuServices()
        {

        }

        public void ShowProducts()
        {
            foreach (Product pd in menuProduct.ListProduct)
            {
                Console.WriteLine(pd.ToString());
            }
        }
    }
}
