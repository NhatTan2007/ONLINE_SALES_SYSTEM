using ONLINE_SALES_SYSTEM.Models;
using ONLINE_SALES_SYSTEM.Ultilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Services
{
    class CustomerServices
    {
        private string strFullPath = Path.Combine(FilePath.strRootDataPath, FilePath.strCustomerPath, FilePath.strCustomerOrderHistoryFileName);
        private Customer _thisCustomer;
        private CartServices _cartServices;
        private OrderServices _orderServices;
        public CustomerServices(ref Customer inputCustomer)
        {
            _thisCustomer = inputCustomer;
            _cartServices = new CartServices(ref _thisCustomer);
            _orderServices = new OrderServices(ref _thisCustomer);
        }

        public void AddNewProductToCart(Product inputProduct, int quantity = 1)
        {
            _cartServices.AddNewProductToCart(inputProduct, quantity);
        }

        public void UpdateQuantityProductExistsInCart(ProductOrder inputProductOrder, int quantity)
        {
            _cartServices.UpdateQuantityProductExistsInCart(inputProductOrder, quantity);
        }

        public void RemoveProductFromCart(ProductOrder inputProduct)
        {
            _cartServices.RemoveProductFromCart(inputProduct);
        }

        public ProductOrder GetProductOrderInCart(string productName)
        {
            return _cartServices.GetProductOrderInCart(productName);
        }

        public Order CreateOrder()
        {
            return _orderServices.CreateOrder();
        }

        public void ShowCart()
        {
            _cartServices.ShowCart();
        }

        public ProductOrder SelectProductOrderFromCart()
        {
            return _cartServices.SelectProductOrderFromCart();
        }
        public void WriteCartJson()
        {
            _cartServices.WriteCartJson();
        }

        public Cart ReadCartJson()
        {
            return _cartServices.ReadCartJson();
        }

        public void WriteCustomerOrderHistoryCustomerJson()
        {
            Common.WriteFileJson(_thisCustomer.ListOrder, strFullPath);
        }

        public List<Order> ReadCustomerOrderHistoryCustomerJson()
        {
            
            if (File.Exists(strFullPath))
            {
                List<Order>? temp = Common.ReadFileJson<List<Order>>(strFullPath);
                if (temp != null) return temp;
            }
            return new List<Order>();
        }
    }
}
