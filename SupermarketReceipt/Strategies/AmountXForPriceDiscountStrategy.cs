using SupermarketReceipt.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketReceipt.Strategies
{
    public class AmountXForPriceYDiscountStrategy : DiscountStrategy
    {
        private int _amountX;
        private double _discountPrice;

        public AmountXForPriceYDiscountStrategy(ProductQuantity product, double price, int amountX, double discountPrice) : base(product, price)
        {
            _amountX = amountX;
            _discountPrice = discountPrice;
        }

        public override Discount GetDiscount()
        {
            if (_product.Quantity < _amountX)
                return null;

            return new Discount(_product.Product, $"{_amountX} for {_discountPrice}", Discount());
        }

        private double Discount()
        {
            return (_price * _product.Quantity) - _discountPrice;
        }
    }
}
