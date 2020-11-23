using System;
namespace Lab2
{
    public class Product
    {
        private string _name;
        private int _quantity;
        private double _price;
        public Product(string name, int quantity, double price = 0)
        {
            _name = name;
            _quantity = quantity;
            _price = price;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public void IncQuantity(int new_quantity)
        {
            _quantity += new_quantity;
        }

        public void DecQuantity(int new_quantity)
        {
            _quantity -= new_quantity;
        }

        public double GetPrice()
        {
            return _price;
        }

        public void SetPrice(double new_price)
        {
            _price = new_price;
        }
    }
}
