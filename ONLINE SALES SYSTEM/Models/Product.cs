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


        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public decimal Price { get => _price; set => _price = value; }

        public Product()
        {
            _id = ++_count;
        }

        public Product(string name, decimal price)
        {
            _name = name;
            _price = price;
        }
        public override string ToString()
        {
            return $"id: {_id}\t\t name:{_name}\t\t price{_price}";
        }
    }
}
