using SupermarketReceipt.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketReceipt
{
    public class ShoppingCart
    {
        public List<ProductQuantity> Items { get; private set; }

        public ShoppingCart()
        {
            Items = new List<ProductQuantity>();
        }

        /// <summary>
        /// Haalt de lijst van alle items in het winkelwagentje op.
        /// Deze method retourneert een lijst van ProductQuantity objecten die de producten
        /// en hun hoeveelheden bevatten die de klant wil kopen.
        /// </summary>
        /// <returns>Een List van ProductQuantity objecten die alle items in het winkelwagentje representeren</returns>
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
}