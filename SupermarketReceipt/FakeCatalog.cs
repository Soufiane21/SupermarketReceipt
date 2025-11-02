using SupermarketReceipt;
using SupermarketReceipt.Entities;
using System;
using System.Collections.Generic;

namespace SupermarketReceiptTests
{
    public class FakeCatalog : ISupermarketCatalog
    {
        private readonly IDictionary<string, double> _prices = new Dictionary<string, double>();
        private readonly IDictionary<string, Product> _products = new Dictionary<string, Product>();

        public void AddProduct(Product product, double price)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            
            if (price < 0)
                throw new ArgumentException("Price cannot be negative", nameof(price));

            _products.Add(product.Name, product);
            _prices.Add(product.Name, price);
        }

        public double GetUnitPrice(Product p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));

            if (!_prices.ContainsKey(p.Name))
                throw new KeyNotFoundException($"Product '{p.Name}' not found in catalog");

            return _prices[p.Name];
        }
    }
}