using SupermarketReceipt.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketReceipt
{
    /// <summary>
    /// Represents a shopping cart that holds products and their quantities.
    /// </summary>
    public class ShoppingCart
    {
        public List<ProductQuantity> Items { get; private set; }

        public ShoppingCart()
        {
            Items = new List<ProductQuantity>();
        }

        /// <summary>
        /// Gets the list of items in the shopping cart.
        /// </summary>
        /// <returns>A list of ProductQuantity objects.</returns>
        public List<ProductQuantity> GetItems()
        {
            return Items;
        }

        /// <summary>
        /// Adds a single product to the shopping cart with a default quantity of 1.
        /// </summary>
        /// <param name="product">The product to add.</param>
        public void AddItem(Product product)
        {
            AddItemQuantity(product, 1.0);
        }

        /// <summary>
        /// Adds a product to the shopping cart with a specified quantity.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <param name="quantity">The quantity of the product.</param>
        public void AddItemQuantity(Product product, double quantity)
        {
            Items.Add(new ProductQuantity(product, quantity));
        }
    }
}