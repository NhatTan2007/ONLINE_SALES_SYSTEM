using ONLINE_SALES_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ONLINE_SALES_SYSTEM.Ultilities;

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
            Order newOrder = new Order();
            newOrder.OrderDetail = new List<ProductOrder>(_myCustomer.MyCart.ListProductOfGuest);
            newOrder.OrderTime = DateTime.UtcNow;
            SetPaidStatus(newOrder);
            _myCustomer.ListOrder.Add(newOrder);
            return newOrder;
        }

        public void SetPaidStatus(Order newOrder)
        {
            int yourChoice;
            bool checkInput = false;
            MenuServices.ShowMenuModePayment();
            back_your_Choice:
            Console.WriteLine("Your choice: ");
            checkInput = int.TryParse(Console.ReadLine().Trim(), out yourChoice);
            while (!checkInput || yourChoice < 0 || yourChoice > 2)
            {
                Console.WriteLine("Your input is wrong, please check again");
                goto back_your_Choice;
            }
            if (yourChoice == 0) return;
            if (yourChoice == 1) newOrder.StatusPayment = OrderStatus.Paid;
            if (yourChoice == 2) newOrder.StatusPayment = OrderStatus.CashOnDelivery;
        }
    }
}
