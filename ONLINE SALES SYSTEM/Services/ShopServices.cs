using ONLINE_SALES_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Services
{
    class ShopServices
    {
        private Shop _shop;
        private MenuProducts _shopMenuProducts;
        private ProductServices _productServicesOfShop;

        public ShopServices(ref Shop inputShop)
        {
            _shop = inputShop;
            _shopMenuProducts = _shop.ProductsOfShop;
            _productServicesOfShop = new ProductServices(ref _shopMenuProducts);
        }

        public void ShowProducts()
        {
            _productServicesOfShop.ShowProducts();
        }

        public int GetNumberOfProducts()
        {
            return _productServicesOfShop.GetNumberOfProducts();
        }

        public Product GetProduct(int productId) 
        {
            return _productServicesOfShop.GetProduct(productId);
        }
    }
}
