using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Models
{
    class ProductOrder
    {
        private string _productName;
        private decimal _productPrice;
        private int _quantity;
        public decimal Amount => _quantity * _productPrice;

        public string ProductName { get => _productName; set => _productName = value; }
        public decimal ProductPrice { get => _productPrice; set => _productPrice = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }

        public ProductOrder(Product inputProduct, int quatity)
        {
            _productName = inputProduct.Name;
            _productPrice = inputProduct.Price;
        }

        public override string ToString()
        {
            return $"Name: {_productName}\t\tPrice: {_productPrice}\tQuantity: {_quantity}\tAmount: {Amount}";
        }
    }
}
