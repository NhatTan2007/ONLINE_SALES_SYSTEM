using ONLINE_SALES_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Services
{
    class CartServices
    {
        private Cart _customerCart;
        public CartServices(ref Customer inputCustomer)
        {
            _customerCart = inputCustomer.MyCart;
        }

        public void AddNewProductToCart(Product inputProduct, int quantity)
        {
            ProductOrder newProductOrder = new ProductOrder(inputProduct, quantity);
            _customerCart.ListProductOfCustomer.Add(newProductOrder);
        }

        public void UpdateQuantityProductExistsInCart(ProductOrder inputProduct, int quantity)
        {
            inputProduct.Quantity += quantity;
        }

        public bool RemoveProductFromCart(ProductOrder productOrderWantToRemove)
        {
            return _customerCart.ListProductOfCustomer.Remove(productOrderWantToRemove);
        }

        public ProductOrder GetProductOrderInCart(string productName)
        {
            foreach (ProductOrder product in _customerCart.ListProductOfCustomer)
            {
                if (product.ProductName == productName) return product;
            }
            return null;
        }

        public void ShowCart()
        {
            for (int i = 0; i < _customerCart.ListProductOfCustomer.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_customerCart.ListProductOfCustomer[i].ToString()}");
            }
        }
    }
}
