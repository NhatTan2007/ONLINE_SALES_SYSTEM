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
            string strFullPath = String.Empty;
            while (true)
            {
            back_To_Menu:
                //Menu
            back_To_Choice:
                Console.Write("Please choose one option above: ");
                checkInput = int.TryParse(Common.ReadDataFromConsole(), out customerChoice);
                while (!checkInput || customerChoice < 0 || customerChoice > 6) //Chua them max option
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
                        strFullPath = Path.Combine(FilePath.strRootDataPath, FilePath.strCustomerPath, FilePath.strCartFileName);
                        Common.WriteFileJson(newCustomer.MyCart, strFullPath);
                        break;
                    case 3:
                        system.ShowCustomerCartDetail();
                        break;
                    case 4:
                        system.DecreaseQuantityProductOrderInCart();
                        break;
                    case 5:
                        int ordinalNumber;
                        system.ShowCustomerCartDetail();
                        Console.WriteLine("Input 0 to cancel");
                    back_input_ordinal_numbers:
                        Console.Write("Select one product in your cart above, please input ordinal numbers:");
                        checkInput = int.TryParse(Common.ReadDataFromConsole(), out ordinalNumber);
                        while (!checkInput || ordinalNumber < 0 || ordinalNumber > newCustomer.MyCart.ListProductOfCustomer.Count)
                        {
                            Console.WriteLine("Please check your input and try again");
                            goto back_input_ordinal_numbers;
                        }
                        if (ordinalNumber == 0) goto back_To_Menu;
                        ProductOrder productOrder = newCustomer.MyCart.ListProductOfCustomer[ordinalNumber - 1];
                        system.RemoveProductFromCart(productOrder);
                        break;
                    case 6:
                        system.CustomerCreateOrder();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
