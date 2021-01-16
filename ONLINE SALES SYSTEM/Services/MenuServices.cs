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
    }
}
