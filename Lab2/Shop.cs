using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Shop
    {
        private string _name;
        private int _index;
        private string _adress;
        private List<Product> _products = new List<Product>();

        public Shop(string name, int index, string adress)
        {
            _name = name;
            _index = index;
            _adress = adress;
        }

        public int GetIndex()
        {
            return _index;
        }
        
        public List<Product> GetProducts()
        {
            return _products;
        }

        public void AddProducts(List<Product> new_products)
        {
            foreach(Product product in new_products)
            {
                Product old_product = _products.Find(item => item.GetName() == product.GetName());
                if (old_product != null)
                {
                    old_product.IncQuantity(product.GetQuantity());
                    old_product.SetPrice(product.GetPrice());
                }
                else
                {
                    _products.Add(product);
                }
            }
        }

        public Dictionary<string, int> ProductsForAmount(double amount)
        {
            Dictionary<string, int> products = new Dictionary<string, int>();
            foreach (var product in _products)
            {
                int number_of = (int)(amount / product.GetPrice());
                if (number_of > product.GetQuantity())
                {
                    products[product.GetName()] = product.GetQuantity();
                }
                else
                {
                    products[product.GetName()] = number_of;
                }
            }
            return products;
        }

        public double BuyProducts(List<Product> products)
        {
            double cost = 0;
            foreach (var product in products)
            {
                bool find = false;
                foreach (var shop_product in _products)
                {
                    if (product.GetName() == shop_product.GetName())
                    {
                        find = true;
                        if (product.GetQuantity() > shop_product.GetQuantity())
                        {
                            return 0;
                        }
                        cost += product.GetQuantity() * shop_product.GetPrice();
                        shop_product.DecQuantity(product.GetQuantity());
                        break;
                    }
                }
                if (!find)
                {
                    return 0;
                }
            }
            return cost;
        }
    }
}
