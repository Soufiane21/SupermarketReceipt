using System.Collections.Generic;
using System.Linq;

namespace SupermarketReceipt
{
    public class ShoppingCart
    {
        private readonly List<ProductQuantity> _items = new List<ProductQuantity>();
        public Dictionary<Product, double> ProductQuantities { get; set; }

        public ShoppingCart()
        {
            ProductQuantities = new Dictionary<Product, double>();
        }

        public List<ProductQuantity> GetItems()
        {
            return new List<ProductQuantity>(_items);
        }

        public void AddItem(Product product)
        {
            AddItemQuantity(product, 1.0);
        }


        public void AddItemQuantity(Product product, double quantity)
        {
            _items.Add(new ProductQuantity(product, quantity));
            if (ProductQuantities.ContainsKey(product))
            {
                var newAmount = ProductQuantities[product] + quantity;
                ProductQuantities[product] = newAmount;
            }
            else
            {
                ProductQuantities.Add(product, quantity);
            }
        }       
    }
}