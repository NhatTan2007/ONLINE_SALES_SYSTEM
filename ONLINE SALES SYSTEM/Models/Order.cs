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
        public string OrderTime { get; set; }
        public List<ProductOrder> OrderDetail { get; set;}
        public OrderStatus StatusPayment { get; set; }
        public decimal TotalPrice { get; set; }

        public Order(Cart inputCart)
        {
            Id = ++_count;
            OrderDetail = new List<ProductOrder>(inputCart.ListProductOfCustomer);
            OrderTime = DateTime.UtcNow.ToString("g");
        }
    }
}
