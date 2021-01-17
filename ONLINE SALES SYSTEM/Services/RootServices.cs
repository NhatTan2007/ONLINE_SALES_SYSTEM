using ONLINE_SALES_SYSTEM.Models;
using ONLINE_SALES_SYSTEM.Ultilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONLINE_SALES_SYSTEM.Services
{
    class RootServices
    {
        private Shop _shop;
        private Customer _customer;
        private ShopServices _shopServices;
        private CustomerServices _customerServices;
        public RootServices(ref Shop inputShop, ref Customer inputCustomer)
        {
            _shop = inputShop;
            _customer = inputCustomer;
            _shopServices = new ShopServices(ref _shop);
            _customerServices = new CustomerServices(ref _customer);
        }
        #region Customer function
        public void CustomerAddProductToCart()
        {
            int idProduct;
            bool checkInput = false;
            Console.WriteLine("Press 0 to cancel");
        back_input_choose_product:
            Console.Write("Please choose one product above by ID to add to your cart: ");
            checkInput = int.TryParse(Common.ReadDataFromConsole(), out idProduct);
            while (!checkInput || idProduct < 0 || idProduct > _shopServices.GetNumberOfProducts())
            {
                Console.WriteLine("Your input is wrong data requirement, please input again");
                goto back_input_choose_product;
            }
            if (idProduct == 0) return;
            Product? productChooseByCustomer = _shopServices.GetProduct(idProduct);
            if (productChooseByCustomer != null)
            {
                int quantityProduct;
            back_input_quantity:
                Console.Write($"Please enter quantity of {productChooseByCustomer.Name} you want to order: ");
                checkInput = int.TryParse(Common.ReadDataFromConsole(), out quantityProduct);
                while (!checkInput || quantityProduct < 0 || quantityProduct > productChooseByCustomer.QuantityInStock)
                {
                    Console.WriteLine($"Please check your input quatity, max product's quantity is {productChooseByCustomer.QuantityInStock}");
                    goto back_input_quantity;
                }
                if (quantityProduct == 0) return;
                ProductOrder? productOrder = _customerServices.GetProductOrderInCart(productChooseByCustomer.Name);
                if (productOrder == null)
                {
                    _customerServices.AddNewProductToCart(productChooseByCustomer, quantityProduct);
                }
                else 
                {
                    _customerServices.UpdateQuantityProductExistsInCart(productOrder, quantityProduct);
                }
                Console.WriteLine($"{productChooseByCustomer.Name} was added into your cart\n");
            } else
            {
                Console.WriteLine("Cannot find product, please check again your input ID");
            }
        }

        public void DecreaseQuantityProductOrderInCart()
        {
            if (_customer.MyCart.ListProductOfCustomer.Count > 0)
            {
                bool checkInput = false;
                int quantityDecrease;
                ProductOrder? productOrder = SelectProductOrderFromCart();
                if (productOrder == null) return;
                back_input_quanity_decrease:
                Console.Write($"Input quantity of product you want to decrease, its quanity now is {productOrder.Quantity}: ");
                checkInput = int.TryParse(Common.ReadDataFromConsole(), out quantityDecrease);
                while (!checkInput || quantityDecrease < 0 || quantityDecrease > productOrder.Quantity)
                {
                    Console.WriteLine("Your input is wrong, please check again");
                    goto back_input_quanity_decrease;
                }
                if (quantityDecrease == productOrder.Quantity)
                {
                    RemoveProductFromCart(productOrder);
                    return;
                }
                productOrder.Quantity -= quantityDecrease;
            }
            
        }

        public void RemoveProductFromCart(ProductOrder inputProduct)
        {
            if (_customer.MyCart.ListProductOfCustomer.Count > 0)
            {
            back_answear:
                Console.Write("Do you want to remove this product from your cart? (Y/N): ");
                string answear = Common.ReadDataFromConsole();
                while (answear != "Y" && answear != "N")
                {
                    Console.WriteLine("Please just input Y or N");
                    goto back_answear;
                }
                if (answear == "N") return;
                _customerServices.RemoveProductFromCart(inputProduct);
                Console.WriteLine($"{inputProduct.ProductName} was removed from your cart");
            }
            else Console.WriteLine("Your cart is empty\n");
        }

        public void ShowCustomerCartDetail()
        {
            _customerServices.ShowCart();
        }

        public Order CustomerCreateOrder()
        {
            Order? order = _customerServices.CreateOrder();
            foreach (ProductOrder item in order.OrderDetail)
            {
                foreach (Product pd in _shop.ProductsOfShop.ListProduct)
                {
                    if (pd.Name == item.ProductName) pd.QuantityInStock -= item.Quantity;
                }
            }
            Console.WriteLine("Your order was created successfully");
            return order;
        }

        public ProductOrder SelectProductOrderFromCart()
        {
            return _customerServices.SelectProductOrderFromCart();
        }
        public void WriteCartJson()
        {
            _customerServices.WriteCartJson();
        }

        public Cart ReadCartJson()
        {
            return _customerServices.ReadCartJson();
        }

        public void WriteCustomerOrderHistoryCustomerJson()
        {
            _customerServices.WriteCustomerOrderHistoryCustomerJson();
        }

        public List<Order> ReadCustomerOrderHistoryCustomerJson()
        {
            return _customerServices.ReadCustomerOrderHistoryCustomerJson();
        }

        #endregion

        #region Shop function
        public void ShowProductOfShop()
        {
            _shopServices.ShowProducts();
        }

        public MenuProducts ReadProductListJson()
        {
            return _shopServices.ReadProductListJson();
        }

        public void WriteProductList()
        {
            _shopServices.WriteProductListJson();
        }
        #endregion
    }
}
