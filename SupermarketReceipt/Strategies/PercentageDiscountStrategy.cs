using SupermarketReceipt.Entities;
using System;

namespace SupermarketReceipt.Strategies
{
    /// <summary>
    /// Strategy for percentage-based discounts (e.g., 10% off, 25% off).
    /// Applies a fixed percentage discount to the total price of the product.
    /// </summary>
    /// <example>
    /// 10% discount on $100 worth of items = -$10 discount
    /// 25% discount on $50 worth of items = -$12.50 discount
    /// </example>
    public class PercentageDiscountStrategy : DiscountStrategy
    {
        private readonly double _discountPercentage;

        /// <summary>
        /// Initializes a new instance of the PercentageDiscountStrategy.
        /// </summary>
        /// <param name="discountPercentage">
        /// The discount percentage as a decimal (e.g., 0.10 for 10%, 0.25 for 25%).
        /// Must be between 0 and 1 (inclusive).
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when discount percentage is less than 0 or greater than 1
        /// </exception>
        public PercentageDiscountStrategy(double discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 1)
                throw new ArgumentException(
                    "Discount percentage must be between 0 and 1 (e.g., 0.10 for 10%)", 
                    nameof(discountPercentage));

            _discountPercentage = discountPercentage;
        }

        /// <summary>
        /// Calculates the percentage discount on the total price.
        /// </summary>
        /// <param name="product">The product being discounted</param>
        /// <param name="quantity">Total quantity purchased</param>
        /// <param name="unitPrice">Price per unit of the product</param>
        /// <returns>
        /// The discount amount as a negative value (e.g., -10.00 for $10 discount)
        /// </returns>
        /// <example>
        /// 10% off 5 items at $20 each:
        /// - Total price: 5 * $20 = $100
        /// - Discount: $100 * 0.10 = -$10
        /// </example>
        public override double CalculateDiscount(Product product, double quantity, double unitPrice)
        {
            double totalPrice = quantity * unitPrice;
            return -totalPrice * _discountPercentage;
        }

        /// <summary>
        /// Gets a human-readable description of this discount.
        /// </summary>
        /// <returns>Description string (e.g., "10% off", "25% off")</returns>
        public override string GetDescription()
        {
            int percentage = (int)(_discountPercentage * 100);
            return $"{percentage}% off";
        }
    }
}