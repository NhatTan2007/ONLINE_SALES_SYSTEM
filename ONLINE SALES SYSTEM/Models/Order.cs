using System;
using System.Collections.Generic;
using System.Text;
using ONLINE_SALES_SYSTEM.Ultilities;

namespace ONLINE_SALES_SYSTEM.Models
{
    class Order
    {
        public string OrderTime { get; set; }
        public List<ProductOrder> OrderDetail { get; set;}
        public string StatusPayment { get; set; }
        public decimal TotalPrice => CalTotalPrice();

        public Order()
        {

        }
        public Order(Cart inputCart)
        {
            OrderDetail = new List<ProductOrder>(inputCart.ListProductOfCustomer);
            OrderTime = DateTime.UtcNow.ToString("g");
        }

        private decimal CalTotalPrice()
        {
            decimal sum = 0;
            if (OrderDetail.Count > 0)
            {
                foreach (ProductOrder item in OrderDetail)
                {
                    sum += item.Amount;
                }
            }
            return sum;
        }
    }
}
