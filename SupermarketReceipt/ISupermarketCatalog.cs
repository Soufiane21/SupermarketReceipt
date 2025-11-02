using SupermarketReceipt.Entities;

namespace SupermarketReceipt
{
    /// <summary>
    /// Interface for supermarket catalog operations
    /// </summary>
    public interface ISupermarketCatalog
    {
        /// <summary>
        /// Adds a product to the catalog with its price
        /// </summary>
        /// <param name="product">The product to add</param>
        /// <param name="price">The price of the product</param>
        void AddProduct(Product product, double price);

        /// <summary>
        /// Gets the unit price of a product
        /// </summary>
        /// <param name="product">The product to get the price for</param>
        /// <returns>The unit price of the product</returns>
        double GetUnitPrice(Product product);
    }
}