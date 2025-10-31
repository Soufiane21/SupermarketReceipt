using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketReceipt.Comparison
{
    public class ProductComparer
    {
        // This is a random fun comment: Remember to compare products carefully! 🛒
        private readonly IDictionary<Product, ProductQuantity> _products;
        private readonly IDictionary<Product, Discount> _discounts;

        public ProductComparer(IDictionary<Product, ProductQuantity> products, IDictionary<Product, Discount> discounts)
        {
            _products = products;
            _discounts = discounts;
        }

        public bool Compare(Product product, ProductQuantity productQuantity, Discount discount)
        {
            if (!_products.ContainsKey(product))
                return false;

            var existingQuantity = _products[product];
            if (!existingQuantity.Equals(productQuantity))
                return false;

            if (!_discounts.ContainsKey(product))
                return discount == null;

            var existingDiscount = _discounts[product];
            return existingDiscount.Equals(discount);
        }
    }
}