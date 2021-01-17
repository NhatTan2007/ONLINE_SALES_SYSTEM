using System;
using ONLINE_SALES_SYSTEM.Ultilities;
using ONLINE_SALES_SYSTEM.Services;
using ONLINE_SALES_SYSTEM.Models;

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
            while (true)
            {
                //Menu
                back_To_Choice:
                Console.Write("Please choose one option above: ");
                checkInput = int.TryParse(Common.ReadDataFromConsole(), out customerChoice);
                while (!checkInput || customerChoice < 0) //Chua them max option
                {
                    Console.WriteLine("Your input wrong requirement, please input again");
                    goto back_To_Choice;
                }
                switch (customerChoice)
                {
                    case 1:
                        system.ShowProductOfShop();
                        break;
                    case 2:
                        system.CustomerAddProductToCart();
                        break;
                    case 3:
                        system.ShowCustomerCartDetail();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
