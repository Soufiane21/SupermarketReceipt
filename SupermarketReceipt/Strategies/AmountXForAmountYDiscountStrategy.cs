using SupermarketReceipt.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketReceipt.Strategies
{
    public class AmountXForAmountYDiscountStrategy : DiscountStrategy, IDiscountStrategy
    {
        private int _amountX;
        private double _amountY;

        public AmountXForAmountYDiscountStrategy(ProductQuantity product, double price, int amountX, double amountY) : base(product, price)
        {
            _amountX = amountX;
            _amountY = amountY;
        }

        public override Discount GetDiscount()
        {
            if (_product.Quantity < _amountX)
                return null;

            return new Discount(_product.Product, $"{_amountX} for {_amountY}", Discount());
        }

        private double Discount()
        {
            return (_price * _product.Quantity) - (_amountY * _price);
        }
    }
}
