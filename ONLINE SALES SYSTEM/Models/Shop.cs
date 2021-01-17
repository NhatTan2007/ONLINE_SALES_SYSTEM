using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Models
{
    class Shop
    {
        private MenuProducts? _productsOfShop;

        public MenuProducts? ProductsOfShop { get => _productsOfShop; set => _productsOfShop = value; }

        public Shop()
        {
            _productsOfShop = new MenuProducts();
        }
    }
}
