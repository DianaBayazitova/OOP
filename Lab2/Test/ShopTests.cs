using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Tests
{
    [TestClass]
    public class ShopTests
    {
        [TestMethod]
        public void ShopsTests()
        {
            Product product = new Product("BEATS Urbeats3", 81, 4260.10);
            Product product1 = new Product("DIGMA E654", 165, 5400.00);
            Product product2 = new Product("SAMSUNG Galaxy M11 32Gb", 2163, 10480.75);
            Product product3 = new Product("BEATS Urbeats3", 41, 4100.00);
            Product product4 = new Product("Xiaomi Smart Scale 2", 982, 1100.00);
            Product product5 = new Product("Samsung Galaxy Watch Active", 82, 17999.99);
            Product product6 = new Product("JBL Party Box 300", 100, 26999.99);
            Product product7 = new Product("APPLE iPhone 11 64Gb", 2, 54490.00);
            Product product8 = new Product("DIGMA E654", 154, 5290.10);
            Product product9 = new Product("SMARTERRA VR", 2, 690.00);

            List<Product> products = new List<Product>
            {
                product,
                product1,
                product2
            };

            List<Product> products1 = new List<Product>
            {
                product3,
                product4,
                product5
            };

            List<Product> products2 = new List<Product>
            {
                product6,
                product7,
                product8,
                product9
            };

            Shop shop = new Shop("Eldorado", 1, "Moskovskaya");
            Shop shop1 = new Shop("MVideo", 2, "Gorkovskaya");
            Shop shop2 = new Shop("Citilink", 3, "Chkalovskaya");

            shop.AddProducts(products);
            shop1.AddProducts(products1);
            shop2.AddProducts(products2);


            List<Shop> shops = new List<Shop>
            {
                shop,
                shop1,
                shop2
            };

            ShopManager shopManager = new ShopManager(shops);

            Assert.AreEqual(2, shopManager.ShopWithCheapestProduct("BEATS Urbeats3"));
            Assert.AreEqual(23905930.35, shop.BuyProducts(products));
            Assert.AreEqual(0, shopManager.ShopWithCheapestConsignmentOfProducts(products));

        }
    }
}
