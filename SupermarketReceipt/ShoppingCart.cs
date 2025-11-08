using SupermarketReceipt.Entities;
using System.Collections.Generic;

namespace SupermarketReceipt
{
    public class ShoppingCart
    {
        public List<ProductQuantity> Items { get; private set; }

        public ShoppingCart()
        {
            Items = new List<ProductQuantity>();
        }

        public List<ProductQuantity> GetItems()
        {
            return Items;
        }

        public void AddItem(Product product)
        {
            AddItemQuantity(product, 1.0);
        }


        public void AddItemQuantity(Product product, double quantity)
        {
            Items.Add(new ProductQuantity(product, quantity));
        }       
    }
    // This is a happy comment! Smiles all around!
}