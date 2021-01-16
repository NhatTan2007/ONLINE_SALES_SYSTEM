using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Models
{
    class Order
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public List<ProductOrder> OrderDetail { get; set;}
        public bool StatusPayment { get; set; }
        public decimal TotalPrice => CalTotalPrice();
        
        private decimal CalTotalPrice()
        {
            decimal sum = 0;
            foreach (ProductOrder item in OrderDetail)
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
