using SupermarketReceipt.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketReceipt
{
    /// <summary>
    /// Represents a shopping cart that holds products and their quantities
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Gets the list of items in the shopping cart
        /// </summary>
        public List<ProductQuantity> Items { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ShoppingCart class
        /// </summary>
        public ShoppingCart()
        {
            Items = new List<ProductQuantity>();
        }

        /// <summary>
        /// Returns all items in the shopping cart
        /// </summary>
        /// <returns>List of product quantities</returns>
        public List<ProductQuantity> GetItems()
        {
            return Items;
        }

        /// <summary>
        /// Adds a single item to the shopping cart
        /// </summary>
        /// <param name="product">The product to add</param>
        public void AddItem(Product product)
        {
            AddItemQuantity(product, 1.0);
        }

        /// <summary>
        /// Adds a product with specified quantity to the shopping cart
        /// </summary>
        /// <param name="product">The product to add</param>
        /// <param name="quantity">The quantity of the product</param>
        public void AddItemQuantity(Product product, double quantity)
        {
            Items.Add(new ProductQuantity(product, quantity));
        }       
    }
}