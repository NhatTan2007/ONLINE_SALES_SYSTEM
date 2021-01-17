using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Models
{
    class MenuProducts
    {
        private List<Product> _listProduct;

        public List<Product> ListProduct { get => _listProduct; set => _listProduct = value; }
        public MenuProducts()
        {

        }
    }
}
