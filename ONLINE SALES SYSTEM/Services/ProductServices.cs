using ONLINE_SALES_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Services
{
    class ProductServices
    {
        public static MenuProduct menuProduct { get; set; }

        public Product GetProduct(int productId)
        {
            foreach (Product pd in menuProduct.ListProduct)
            {
                if(pd.Id == productId)
                {
                    return pd;
                }
            }
            return new Product();
        }
    }
}
