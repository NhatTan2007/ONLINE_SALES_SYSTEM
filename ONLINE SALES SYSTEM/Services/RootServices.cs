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

        public void DecreaseQuantityProductOrderInCart()
        {
            ShowCustomerCartDetail();
            int customerChoice;
            bool checkInput = false;
            int quantityDecrease;
            Console.WriteLine("Input 0 to cancel");
        back_input_ordinal_numbers:
            Console.Write("Select one product in your cart above, please input ordinal numbers:");
            checkInput = int.TryParse(Common.ReadDataFromConsole(), out customerChoice);
            while (!checkInput || customerChoice < 0 || customerChoice > _customer.MyCart.ListProductOfCustomer.Count)
            {
                Console.WriteLine("Please check your input and try again");
                goto back_input_ordinal_numbers;
            }
            if (customerChoice == 0) return;
            ProductOrder productOrder = _customer.MyCart.ListProductOfCustomer[customerChoice - 1];
        back_input_quanity_decrease:
            Console.Write($"Input quantity of product you want to decrease, its quanity now is {productOrder.Quantity}");
            checkInput = int.TryParse(Common.ReadDataFromConsole(), out quantityDecrease);
            while (!checkInput || quantityDecrease < 0 || quantityDecrease > productOrder.Quantity)
            {
                Console.WriteLine("Your input is wrong, please check again");
                goto back_input_quanity_decrease;
            }
            if (quantityDecrease == productOrder.Quantity)
            {
                RemoveProductFromCart(productOrder);
                return;
            }
            productOrder.Quantity -= quantityDecrease;
        }

        public void RemoveProductFromCart(ProductOrder inputProduct)
        {
        back_answear:
            Console.WriteLine("Do you want to remove this product from your cart? (Y/N)");
            string answear = Common.ReadDataFromConsole();
            while (answear != "Y" && answear != "N")
            {
                Console.WriteLine("Please just input Y or N");
                goto back_answear;
            }
            if (answear == "N") return;
            _customerServices.RemoveProductFromCart(inputProduct);
        }
        public void ShowProductOfShop()
        {
            _shopServices.ShowProducts();
        }

        public void ShowCustomerCartDetail()
        {
            Console.WriteLine("Your cart\n");
            _customerServices.ShowCart();
        }

        public Order CustomerCreateOrder()
        {
            return _customerServices.CreateOrder();
        }
    }
}
