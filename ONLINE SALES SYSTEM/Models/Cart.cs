using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Models
{
    class Cart
    {
        private List<ProductOrder> _listProductOfCustomer;
        public List<ProductOrder> ListProductOfCustomer { get => _listProductOfCustomer; set => _listProductOfCustomer = value; }
        public decimal TotalPrice => CalTotalPrice();

        public Cart()
        {
            _listProductOfCustomer = new List<ProductOrder>();
        }
        
        private decimal CalTotalPrice()
        {
            decimal sum = 0;
            if (_listProductOfCustomer != null)
            {
                foreach (ProductOrder item in _listProductOfCustomer)
                {
                    sum += item.Amount;
                }
            }
            return sum;
        }
    }
}
