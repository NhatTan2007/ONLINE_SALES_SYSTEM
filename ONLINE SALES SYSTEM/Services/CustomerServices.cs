using ONLINE_SALES_SYSTEM.Models;
using ONLINE_SALES_SYSTEM.Ultilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Services
{
    class CustomerServices
    {
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


    }
}
