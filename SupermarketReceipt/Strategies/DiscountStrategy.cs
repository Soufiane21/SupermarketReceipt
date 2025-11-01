using SupermarketReceipt.Entities;

namespace SupermarketReceipt.Strategies
{
    /// <summary>
    /// Abstract base class for all discount calculation strategies.
    /// Implements the Strategy pattern to allow different discount calculation methods.
    /// </summary>
    /// <remarks>
    /// Each concrete strategy must implement:
    /// - CalculateDiscount: Calculate the actual discount amount
    /// - GetDescription: Provide a human-readable description of the discount
    /// 
    /// All discount amounts should be returned as NEGATIVE values to subtract from total.
    /// </remarks>
    public abstract class DiscountStrategy
    {
        /// <summary>
        /// Calculates the discount amount for a given product and quantity.
        /// </summary>
        /// <param name="product">The product being discounted</param>
        /// <param name="quantity">The quantity of the product purchased</param>
        /// <param name="unitPrice">The price per unit of the product</param>
        /// <returns>
        /// The discount amount as a NEGATIVE value (e.g., -5.00 for $5 discount).
        /// Returns 0 if no discount applies.
        /// </returns>
        public abstract double CalculateDiscount(Product product, double quantity, double unitPrice);

        /// <summary>
        /// Gets a human-readable description of this discount strategy.
        /// </summary>
        /// <returns>A string describing the discount (e.g., "3 for 2", "10% off")</returns>
        public abstract string GetDescription();
    }
}