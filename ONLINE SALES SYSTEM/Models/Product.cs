using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Models
{
    class Product
    {
        public static int _count = 0;
        private int _id;
        private string _name;
        private decimal _price;
        private int _quantityInStock;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public decimal Price { get => _price; set => _price = value; }
        public int QuantityInStock { get => _quantityInStock; set => _quantityInStock = value; }
        public Product()
        {

        }

        public Product(string name, decimal price, int quantity)
        {
            _id = ++_count;
            _name = name;
            _price = price;
            _quantityInStock = quantity;
        }

        public override string ToString()
        {
            return $"Id: {_id}\tName: {_name}\n\n" +
                $"Price: {_price}\t\tQuantity in Stock: {_quantityInStock}\n" +
                $"--------------------------------------------------------";
        }
    }
}
