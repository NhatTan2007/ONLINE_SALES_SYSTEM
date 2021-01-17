using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Models
{
    class Customer
    {
        private List<Order> _listOrder;
        private Cart _myCart;
        public List<Order> ListOrder { get => _listOrder; set => _listOrder = value; }
        public Cart MyCart { get => _myCart; set => _myCart = value; }
    }
}
