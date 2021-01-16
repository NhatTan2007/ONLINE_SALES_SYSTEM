using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Models
{
    class Order
    {
        public int Id { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<ProductWantOrder> productWantOrdersList { get; set;}
        public bool Status { get; set; }
        public decimal TotalPrice => CalTotalPrice();
        
        private decimal CalTotalPrice()
        {
            decimal sum = 0;
            foreach (ProductWantOrder item in productWantOrdersList)
            {
                sum += item._amout;
            }
            return sum;
        }
        public Order()
        {

        }

        

    }
}
