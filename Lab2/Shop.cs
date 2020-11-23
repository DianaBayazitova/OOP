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

        public void AddProducts(List<Product> new_products)
        {
            foreach(Product product in new_products)
            {
                int k = 0;
                foreach(Product old_product in _products)
                {
                    if (old_product.GetName() == product.GetName())
                    {
                        old_product.IncQuantity(product.GetQuantity());
                        old_product.SetPrice(product.GetPrice());
                        break;
                    }
                    k++;
                }
                if (k == _products.Count)
                {
                    _products.Add(product);
                }
            }
        }

        public static int ShopWithCheapestProduct(List<Shop> shops, string product_name)
        {
            double min = double.MaxValue;
            int index_min = -1;
            foreach (var shop in shops)
            {
                foreach (var product in shop._products)
                {
                    if (product.GetName() == product_name)
                    {
                        if (min > product.GetPrice())
                        {
                            index_min = shop._index;
                            min = product.GetPrice();
                        }
                        break;
                    }
                }
            }

            return index_min;
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

        public static int BuyCheapestProducts(List<Shop> shops, List<Product> products)
        {
            double min_cost = double.MaxValue;
            int index = 0;
            foreach (var shop in shops)
            {
                double cost = shop.BuyProducts(products);
                if (cost < min_cost && Math.Abs(cost) > double.Epsilon)
                {
                    index = shop._index;
                    min_cost = cost;
                }
            }
            return index;
        }
    }

}
