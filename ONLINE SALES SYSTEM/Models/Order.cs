using System;
using System.Collections.Generic;
using System.Text;
using ONLINE_SALES_SYSTEM.Ultilities;

namespace ONLINE_SALES_SYSTEM.Models
{
    class Order
    {
        private static int _count = 0;
        public int Id { get; set; }
        public DateTime? OrderTime { get; set; }
        public List<ProductOrder> OrderDetail { get; set;}
        public OrderStatus StatusPayment { get; set; }
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

            OrderDetail = new List<ProductOrder>();
            OrderTime = null;
        }

        

    }
}
