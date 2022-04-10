using SupermarketReceipt.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketReceipt.Strategies
{
    public class PercentageDiscountStrategy : DiscountStrategy
    {
        private double _percentage;

        public PercentageDiscountStrategy(ProductQuantity product, double price, double percentage) : base (product, price)
        {
            _percentage = percentage; 
        }

        public override Discount GetDiscount()
        {
            return new Discount(_product.Product, $"{_percentage}% off", (_product.Quantity * _price) * (_percentage / 100));
        }
    }
}
