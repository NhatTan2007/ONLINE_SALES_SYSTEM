using ONLINE_SALES_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Services
{
    class MenuServices
    {
        public static void ShowMenuModePayment()
        {
            Console.WriteLine("Please select your Mode of payment");
            Console.WriteLine("1. Pay now");
            Console.WriteLine("2. Cash on delivery");
            Console.WriteLine("0. Cancel Order");
        }
        public static void ShowMainMenu()
        {
            Console.WriteLine("please choice your desired function: ");
            Console.WriteLine("1. Show Products of shop");
            Console.WriteLine("2. Add products to cart");
            Console.WriteLine("3. Show Products into cart");
            Console.WriteLine("4. Remove quantity of product");
            Console.WriteLine("5. Remove products from the cart");
            Console.WriteLine("6. payment");
            Console.WriteLine("7. Exit");
        }
    }
}