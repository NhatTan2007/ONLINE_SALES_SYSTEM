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
        }
        public static void ShowMainMenu()
        {
            Console.WriteLine("WELCOME TO YOLO SHOP\n");
            Console.WriteLine("1. Show all shop's products");
            Console.WriteLine("2. Add products to cart");
            Console.WriteLine("3. Show products in cart");
            Console.WriteLine("4. Decrease quantity product in cart");
            Console.WriteLine("5. Remove products from the cart");
            Console.WriteLine("6. Make Order");
            Console.WriteLine("0. Exit");
        }
    }
}