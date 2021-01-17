using ONLINE_SALES_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ONLINE_SALES_SYSTEM.Ultilities;

namespace ONLINE_SALES_SYSTEM.Services
{
    class ProductServices
    {
        private string strFullPath => Path.Combine(FilePath.strRootDataPath, FilePath.strShopPath, FilePath.strProductListFileName);
        private Shop _shop;
        public ProductServices(ref Shop inputShop)
        {
            _shop = inputShop;
        }

        public Product GetProduct(int productId)
        {
            foreach (Product pd in _shop.ProductsOfShop.ListProduct)
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
            foreach (Product pd in _shop.ProductsOfShop.ListProduct)
            {
                Console.WriteLine(pd.ToString());
            }
        }

        public int GetNumberOfProducts()
        {
            return _shop.ProductsOfShop.ListProduct.Count;
        }

        public MenuProducts ReadProductListJson()
        {
            return Common.ReadFileJson<MenuProducts>(strFullPath);
        }

        public void WriteProductListJson()
        {
            Common.WriteFileJson(_shop.ProductsOfShop, strFullPath);
        }
    }
}
