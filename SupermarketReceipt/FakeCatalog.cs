using SupermarketReceipt;
using SupermarketReceipt.Entities;
using System.Collections.Generic;

namespace SupermarketReceiptTests
{
    public class FakeCatalog : ISupermarketCatalog
    {
        private readonly IDictionary<string, double> _prices = new Dictionary<string, double>();
        private readonly IDictionary<string, Product> _products = new Dictionary<string, Product>();

        public void AddProduct(Product product, double price)
        {
            _products.Add(product.Name, product);
            _prices.Add(product.Name, price);
        }

        public double GetUnitPrice(Product p)
        {
            return _prices[p.Name];
        }
    }
}