using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Models
{
    class Cart
    {
        private List<ProductOrder> listProductOfGuest;
        public List<ProductOrder> ListProductOfGuest { get => listProductOfGuest; set => listProductOfGuest = value; }
    }
}
