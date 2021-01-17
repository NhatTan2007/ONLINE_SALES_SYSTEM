using ONLINE_SALES_SYSTEM.Models;
using ONLINE_SALES_SYSTEM.Ultilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Services
{
    class RootServices
    {
        private Shop _shop;
        private Customer _customer;
        private ShopServices _shopServices;
        private CustomerServices _customerServices;
        public RootServices(ref Shop inputShop, ref Customer inputCustomer)
        {
            _shop = inputShop;
            _customer = inputCustomer;
            _shopServices = new ShopServices(ref inputShop);
            _customerServices = new CustomerServices(ref inputCustomer);
        }

        public void CustomerAddProductToCart()
        {
            int idProduct;
            bool checkInput = false;
            Console.WriteLine("Press 0 to cancel");
        back_input_choose_product:
            Console.Write("Please choose one product above by ID to add to your cart: ");
            checkInput = int.TryParse(Common.ReadDataFromConsole(), out idProduct);
            while (!checkInput || idProduct < 0 || idProduct > _shopServices.GetNumberOfProducts())
            {
                Console.WriteLine("Your input is wrong data requirement, please input again");
                goto back_input_choose_product;
            }
            if (idProduct == 0) return;
            Product? productChooseByCustomer = _shopServices.GetProduct(idProduct);
            if (productChooseByCustomer != null)
            {
                int quantityProduct;
            back_input_quantity:
                Console.Write($"Please enter quantity of {productChooseByCustomer.Name} you want to order: ");
                checkInput = int.TryParse(Common.ReadDataFromConsole(), out quantityProduct);
                while (!checkInput || quantityProduct < 0 || quantityProduct > productChooseByCustomer.QuantityInStock)
                {
                    Console.WriteLine("Please check your input quatity");
                    goto back_input_quantity;
                }
                if (quantityProduct == 0) return;
                ProductOrder? productOrder = _customerServices.GetProductOrderInCart(productChooseByCustomer.Name);
                if (productOrder == null)
                {
                    _customerServices.AddNewProductToCart(productChooseByCustomer, quantityProduct);
                }
                else 
                {
                    _customerServices.UpdateQuantityProductExistsInCart(productOrder, quantityProduct);
                }
                Console.WriteLine($"{productChooseByCustomer.Name} was added into your cart");
            } else
            {
                Console.WriteLine("Cannot find product, please check again your input ID");
            }
        }
        public void ShowProductOfShop()
        {
            _shopServices.ShowProducts();
        }

        public void ShowCustomerCartDetail()
        {
            Console.WriteLine("Cart of Customer\n");
            _customerServices.ShowCart();
        }
    }
}
