using SupermarketReceipt.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketReceipt.Strategies
{
    public interface IDiscountStrategy
    {
        public Discount GetDiscount();
    }
}
