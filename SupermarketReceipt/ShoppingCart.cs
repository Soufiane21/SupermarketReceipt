using SupermarketReceipt.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketReceipt
{
    public class ShoppingCart
    {
        public List<ProductQuantity> Items { get; private set; }

        /// <summary>
        /// Initialiseert een nieuw exemplaar van de ShoppingCart klasse.
        /// Deze constructor maakt een lege winkelwagen aan door een nieuwe lijst 
        /// van ProductQuantity objecten te instantiëren. De lijst wordt gebruikt om 
        /// alle producten en hun hoeveelheden bij te houden die de klant wil kopen.
        /// Dit is het startpunt voor elke winkelervaring - een lege mand die klaar 
        /// staat om gevuld te worden met artikelen.
        /// </summary>
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
}