using SupermarketReceipt.Entities;
using System;

namespace SupermarketReceipt.Strategies
{
    /// <summary>
    /// Strategy for "Buy X, Get Y Free" promotions (e.g., Buy 2, Get 1 Free).
    /// Calculates discount by giving free items based on purchase quantity.
    /// </summary>
    /// <example>
    /// Buy 2, Get 1 Free: Customer pays for 2, gets 3 items total.
    /// Buy 3, Get 2 Free: Customer pays for 3, gets 5 items total.
    /// </example>
    public class BuyXGetYFreeStrategy : DiscountStrategy
    {
        private readonly int _buyQuantity;
        private readonly int _freeQuantity;

        /// <summary>
        /// Initializes a new instance of the BuyXGetYFreeStrategy.
        /// </summary>
        /// <param name="buyQuantity">Number of items customer must buy</param>
        /// <param name="freeQuantity">Number of items customer gets free</param>
        /// <exception cref="ArgumentException">Thrown when quantities are less than 1</exception>
        public BuyXGetYFreeStrategy(int buyQuantity, int freeQuantity)
        {
            if (buyQuantity < 1)
                throw new ArgumentException("Buy quantity must be at least 1", nameof(buyQuantity));
            
            if (freeQuantity < 1)
                throw new ArgumentException("Free quantity must be at least 1", nameof(freeQuantity));

            _buyQuantity = buyQuantity;
            _freeQuantity = freeQuantity;
        }

        /// <summary>
        /// Calculates the discount amount based on how many complete sets of (buy + free) items were purchased.
        /// </summary>
        /// <param name="product">The product being discounted</param>
        /// <param name="quantity">Total quantity purchased</param>
        /// <param name="unitPrice">Price per unit of the product</param>
        /// <returns>Total discount amount (negative value)</returns>
        /// <example>
        /// Buy 2 Get 1 Free with 5 items at $10 each:
        /// - Complete sets: 5 / (2+1) = 1 set
        /// - Free items: 1 set * 1 free = 1 item
        /// - Discount: 1 * $10 = -$10
        /// </example>
        public override double CalculateDiscount(Product product, double quantity, double unitPrice)
        {
            int totalItemsPerPromotion = _buyQuantity + _freeQuantity;
            int numberOfCompleteSets = (int)(quantity / totalItemsPerPromotion);
            int totalFreeItems = numberOfCompleteSets * _freeQuantity;
            
            return -totalFreeItems * unitPrice;
        }

        /// <summary>
        /// Gets a human-readable description of this promotion.
        /// </summary>
        /// <returns>Description string (e.g., "Buy 2 Get 1 Free")</returns>
        public override string GetDescription()
        {
            return $"Buy {_buyQuantity} Get {_freeQuantity} Free";
        }
    }
}