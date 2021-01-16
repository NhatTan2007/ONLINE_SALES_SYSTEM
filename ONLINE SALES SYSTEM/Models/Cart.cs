using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Models
{
    class Cart
    {
        private List<ProductOrder> _orderDetail;

        public List<ProductOrder> OrderDetail { get => _orderDetail; set => _orderDetail = value; }
    }
}
