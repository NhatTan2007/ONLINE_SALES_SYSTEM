using System;
using ONLINE_SALES_SYSTEM.Ultilities;
using ONLINE_SALES_SYSTEM.Services;
using ONLINE_SALES_SYSTEM.Models;
using System.IO;

namespace ONLINE_SALES_SYSTEM
{
    class Program
    {
        static void Main(string[] args)
        {
            int customerChoice;
            bool checkInput = false;
            Customer newCustomer = new Customer();
            Shop newShop = new Shop();
            RootServices system = new RootServices(ref newShop, ref newCustomer);
            //Read Cart data of customer if customer not create order yet
            newCustomer.MyCart = system.ReadCartJson();
            //Read Customer Order Hisotry
            newCustomer.ListOrder = system.ReadCustomerOrderHistoryCustomerJson();
            //Read Product list of shop
            newShop.ProductsOfShop = system.ReadProductListJson();

            while (true)
            {
                MenuServices.ShowMainMenu();
            back_To_Choice:
                Console.Write("Please choose one option above: ");
                checkInput = int.TryParse(Common.ReadDataFromConsole(), out customerChoice);
                while (!checkInput || customerChoice < 0 || customerChoice > 6)
                {
                    Console.WriteLine("Your input wrong requirement, please input again");
                    goto back_To_Choice;
                }
                Console.WriteLine();
                switch (customerChoice)
                {
                    //Show all products of Shop
                    case 1:
                        system.ShowProductOfShop();
                        break;
                    //Customer add product to cart
                    case 2:
                        system.CustomerAddProductToCart();
                        system.WriteCartJson();
                        break;
                    //Show customer cart detail
                    case 3:
                        system.ShowCustomerCartDetail();
                        break;
                    //Decrease quantity Product Order in customer Cart
                    case 4:
                        system.DecreaseQuantityProductOrderInCart();
                        system.WriteCartJson();
                        break;
                    //Select and remove Product Order from Cart
                    case 5:
                        ProductOrder? productOrder = system.SelectProductOrderFromCart();
                        system.RemoveProductFromCart(productOrder);
                        system.WriteCartJson();
                        break;
                    case 6:
                        //Customer create Order
                        if (newCustomer.MyCart.ListProductOfCustomer.Count > 0)
                        {
                            system.CustomerCreateOrder();
                            system.WriteCartJson();
                            system.WriteProductList();
                            system.WriteCustomerOrderHistoryCustomerJson();
                        }
                        else Console.WriteLine("Your cart is empty\n");
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
