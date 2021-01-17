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

        public ProductOrder()
        {

        }
        public ProductOrder(Product inputProduct, int quantity)
        {
            _productName = inputProduct.Name;
            _productPrice = inputProduct.Price;
            _quantity = quantity;
        }

        public override string ToString()
        {
            return $"Name: {_productName}\n" +
                $"Price: {_productPrice}\t\tQuantity: {_quantity}\tAmount: {Amount}";
        }
    }
}
