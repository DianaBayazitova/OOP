using System;
using System.Collections.Generic;

namespace Lab2
{
    public class ShopManager
    {
        private List<Shop> _shops;

        public ShopManager(List<Shop> shops)
        {
            _shops = shops;
        }
        public int ShopWithCheapestProduct(string product_name)
        {
            double min = double.MaxValue;
            int index_min = -1;
            foreach (var shop in _shops)
            {
                Product product = shop.GetProducts().Find(item => item.GetName() == product_name);
                if (product != null && min > product.GetPrice())
                {
                    index_min = shop.GetIndex();
                    min = product.GetPrice();
                }
            }
            return index_min;
        }
        public Shop ShopWithCheapestConsignmentOfProducts(List<Product> products)
        {
            double min_cost = double.MaxValue;
            Shop found = null;
            foreach (var shop in _shops)
            {
                double cost = shop.BuyProducts(products);
                if (cost < min_cost && Math.Abs(cost) > double.Epsilon)
                {
                    found = shop;
                    min_cost = cost;
                }
            }
            return found;
        }
    }
}
