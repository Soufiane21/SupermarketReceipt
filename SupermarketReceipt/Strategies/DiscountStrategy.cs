using SupermarketReceipt.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketReceipt.Strategies
{
    public abstract class DiscountStrategy : IDiscountStrategy
    {
        protected ProductQuantity _product;
        protected double _price;

        public DiscountStrategy(ProductQuantity product, double price)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));
            _price = price;
        }

        public abstract Discount GetDiscount();
    }
}
