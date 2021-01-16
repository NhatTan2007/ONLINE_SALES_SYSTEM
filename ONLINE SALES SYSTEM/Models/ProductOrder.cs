using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Models
{
    class ProductWantOrder
    {
        private string _productName;
        private decimal _productPrice;
        private int _quantity;
        public decimal _amout => Quantity * ProductPrice;

        public string ProductName { get => _productName; set => _productName = value; }
        public decimal ProductPrice { get => _productPrice; set => _productPrice = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }

        public ProductWantOrder(Product inputProduct)
        {
            _productName = inputProduct.Name;
            _productPrice = inputProduct.Price;
        }
    }
}
