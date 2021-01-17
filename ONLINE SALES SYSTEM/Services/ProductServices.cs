using ONLINE_SALES_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Services
{
    class ProductServices
    {
        private MenuProducts _menuProduct;
        public ProductServices(ref MenuProducts inputMenuProducts)
        {
            _menuProduct = inputMenuProducts;
        }

        public Product GetProduct(int productId)
        {
            foreach (Product pd in _menuProduct.ListProduct)
            {
                if(pd.Id == productId)
                {
                    return pd;
                }
            }
            return null;
        }
        public void ShowProducts()
        {
            Console.WriteLine("Products list of Shop\n");
            foreach (Product pd in _menuProduct.ListProduct)
            {
                Console.WriteLine(pd.ToString());
            }
        }
    }
}
