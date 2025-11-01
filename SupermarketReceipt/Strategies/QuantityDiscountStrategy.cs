using SupermarketReceipt.Entities;
using System;

namespace SupermarketReceipt.Strategies
{
    /// <summary>
    /// Strategy for quantity-based bulk discounts (e.g., "3 for $5", "5 for $20").
    /// Applies a special price when purchasing a specific quantity or more.
    /// </summary>
    /// <example>
    /// "3 for $5" promotion:
    /// - Buy 3 items: Pay $5 instead of regular price
    /// - Buy 6 items: Pay $10 (2 sets of 3)
    /// - Buy 4 items: Pay $5 for first 3, regular price for 1
    /// </example>
    public class QuantityDiscountStrategy : DiscountStrategy
    {
        private readonly int _requiredQuantity;
        private readonly double _specialPrice;

        /// <summary>
        /// Initializes a new instance of the QuantityDiscountStrategy.
        /// </summary>
        /// <param name="requiredQuantity">
        /// Minimum number of items required to get the special price
        /// </param>
        /// <param name="specialPrice">
        /// The special bulk price for the required quantity (total, not per item)
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when required quantity is less than 1 or special price is negative
        /// </exception>
        public QuantityDiscountStrategy(int requiredQuantity, double specialPrice)
        {
            if (requiredQuantity < 1)
                throw new ArgumentException(
                    "Required quantity must be at least 1", 
                    nameof(requiredQuantity));
            
            if (specialPrice < 0)
                throw new ArgumentException(
                    "Special price cannot be negative", 
                    nameof(specialPrice));

            _requiredQuantity = requiredQuantity;
            _specialPrice = specialPrice;
        }

        /// <summary>
        /// Calculates discount by comparing bulk pricing to regular pricing.
        /// </summary>
        /// <param name="product">The product being discounted</param>
        /// <param name="quantity">Total quantity purchased</param>
        /// <param name="unitPrice">Regular price per unit of the product</param>
        /// <returns>
        /// The discount amount as a negative value.
        /// Returns 0 if quantity is less than required quantity.
        /// </returns>
        /// <example>
        /// "3 for $5" with 7 items at $2 each:
        /// - Complete sets: 7 / 3 = 2 sets
        /// - Remaining items: 7 % 3 = 1 item
        /// - Cost with discount: (2 * $5) + (1 * $2) = $12
        /// - Cost without discount: 7 * $2 = $14
        /// - Discount: $12 - $14 = -$2
        /// </example>
        public override double CalculateDiscount(Product product, double quantity, double unitPrice)
        {
            if (quantity < _requiredQuantity)
                return 0;

            int numberOfCompleteSets = (int)(quantity / _requiredQuantity);
            double remainingItems = quantity % _requiredQuantity;

            double totalWithDiscount = (numberOfCompleteSets * _specialPrice) + 
                                      (remainingItems * unitPrice);
            double totalWithoutDiscount = quantity * unitPrice;

            return totalWithDiscount - totalWithoutDiscount;
        }

        /// <summary>
        /// Gets a human-readable description of this bulk discount.
        /// </summary>
        /// <returns>
        /// Description string (e.g., "3 for $5.00", "5 for $20.00")
        /// </returns>
        public override string GetDescription()
        {
            return $"{_requiredQuantity} for ${_specialPrice:F2}";
        }
    }
}