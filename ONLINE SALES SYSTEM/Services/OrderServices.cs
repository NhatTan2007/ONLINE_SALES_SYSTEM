using ONLINE_SALES_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ONLINE_SALES_SYSTEM.Ultilities;
using System.IO;

namespace ONLINE_SALES_SYSTEM.Services
{
    class OrderServices
    {
        private Customer _myCustomer;
        public Customer MyCustomer { get => _myCustomer; set => _myCustomer = value; }
        public OrderServices(ref Customer inputCustomer)
        {
            _myCustomer = inputCustomer;
        }

        public Order CreateOrder()
        {
            Order newOrder = new Order(_myCustomer.MyCart);
            SetPaidStatus(newOrder);
            _myCustomer.ListOrder.Add(newOrder);
            _myCustomer.MyCart.ListProductOfCustomer.Clear();
            WriteOrderJson(newOrder);
            return newOrder;
        }

        public void SetPaidStatus(Order newOrder)
        {
            int yourChoice;
            bool checkInput = false;
            MenuServices.ShowMenuModePayment();
            back_your_Choice:
            Console.Write("Your choice: ");
            checkInput = int.TryParse(Console.ReadLine().Trim(), out yourChoice);
            while (!checkInput || yourChoice <= 0 || yourChoice > 2)
            {
                Console.WriteLine("Your input is wrong, please check again");
                goto back_your_Choice;
            }
            if (yourChoice == 1) newOrder.StatusPayment = "Paid";
            if (yourChoice == 2) newOrder.StatusPayment = "Cash On Delivery";
        }

        private void WriteOrderJson(Order inputOrder)
        {
            FilePath.strOrderFileName = $"Order_{DateTime.UtcNow.ToString("dd.MM.yyyy.hh.mm.ss")}";
            string strFullPath = Path.Combine(FilePath.strRootDataPath, FilePath.strCustomerPath, FilePath.strOrderPath, FilePath.strOrderFileName);
            Common.WriteFileJson(inputOrder, strFullPath);
        }
    }
}
