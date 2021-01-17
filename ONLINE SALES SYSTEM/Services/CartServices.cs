using ONLINE_SALES_SYSTEM.Models;
using ONLINE_SALES_SYSTEM.Ultilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Services
{
    class CartServices
    {
        private Customer _customer;
        private string strFullPath = Path.Combine(FilePath.strRootDataPath, FilePath.strCustomerPath, FilePath.strCartFileName);
        public CartServices(ref Customer inputCustomer)
        {
            _customer = inputCustomer;
        }

        public void AddNewProductToCart(Product inputProduct, int quantity)
        {
            ProductOrder newProductOrder = new ProductOrder(inputProduct, quantity);
            _customer.MyCart.ListProductOfCustomer.Add(newProductOrder);
        }

        public void UpdateQuantityProductExistsInCart(ProductOrder inputProduct, int quantity)
        {
            inputProduct.Quantity += quantity;
        }

        public bool RemoveProductFromCart(ProductOrder productOrderWantToRemove)
        {
            return _customer.MyCart.ListProductOfCustomer.Remove(productOrderWantToRemove);
        }

        public ProductOrder GetProductOrderInCart(string productName)
        {
            if (_customer.MyCart.ListProductOfCustomer.Count != 0)
            {
                foreach (ProductOrder product in _customer.MyCart.ListProductOfCustomer)
                {
                    if (product.ProductName == productName) return product;
                }
            }
            return null;
        }

        public void ShowCart()
        {
            if (_customer.MyCart.ListProductOfCustomer.Count > 0)
            {
                Console.WriteLine("Your cart\n");
                for (int i = 0; i < _customer.MyCart.ListProductOfCustomer.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_customer.MyCart.ListProductOfCustomer[i].ToString()}\n");
                }
            } else Console.WriteLine("Your cart is empty\n");

        }

        public void WriteCartJson()
        {
            Common.WriteFileJson(_customer.MyCart, strFullPath);
        }

        public Cart ReadCartJson()
        {
            Cart? readCart = Common.ReadFileJson<Cart>(strFullPath);
            if (readCart == null) return new Cart();
            return readCart;
        }

        public ProductOrder SelectProductOrderFromCart()
        {
            ShowCart();
            int customerChoice;
            bool checkInput = false;
            Console.WriteLine("Input 0 to cancel");
        back_input_ordinal_numbers:
            Console.Write("Select one product in your cart above, please input ordinal numbers: ");
            checkInput = int.TryParse(Common.ReadDataFromConsole(), out customerChoice);
            while (!checkInput || customerChoice < 0 || customerChoice > _customer.MyCart.ListProductOfCustomer.Count)
            {
                Console.WriteLine("Please check your input and try again");
                goto back_input_ordinal_numbers;
            }
            if (customerChoice == 0) return null;
            return _customer.MyCart.ListProductOfCustomer[customerChoice - 1];
        }

        public void ClearCart()
        {
            _customer.MyCart.ListProductOfCustomer.Clear();
        }

    }
}
