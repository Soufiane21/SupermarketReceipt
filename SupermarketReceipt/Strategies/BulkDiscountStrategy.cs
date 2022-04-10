using SupermarketReceipt.Comparison;
using SupermarketReceipt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketReceipt.Strategies
{
    public class BulkDiscountStrategy : DiscountStrategy
    {
        private Offer _offer;
        private ShoppingCart _shoppingCart;
        private ISupermarketCatalog _catalog;

        public BulkDiscountStrategy(ProductQuantity product, double price, Offer offer, ShoppingCart shoppingCart, ISupermarketCatalog catalog) : base(product, price)
        {
            _offer = offer ?? throw new ArgumentNullException(nameof(offer));
            _shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
            _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
        }

        public override Discount GetDiscount()
        {
            if (!AllItemsInShoppingCart(_offer))
                return null;

            var offerProductsInShoppingCart = _shoppingCart.Items.Where(i => _offer.Products.Contains(i.Product)).ToList();
            var quantities = offerProductsInShoppingCart.Select(p => p.Quantity);
            var numberOfDiscounts = quantities.Max() - (quantities.Max() - quantities.Min());

            var discount = (offerProductsInShoppingCart.Sum(i => _catalog.GetUnitPrice(i.Product)) * numberOfDiscounts) * 0.10;

            // Verwijder alle items omdat deze dan al gescand zijn.
            _shoppingCart.Items.RemoveAll(i => offerProductsInShoppingCart.Contains(i));

            return new Discount(_product.Product, "10% off", discount);
        }

        private bool AllItemsInShoppingCart(Offer offer)
        {
            var productsInShoppingCart = _shoppingCart.Items.Select(s => s.Product);
            var shoppingCartLookUp = _shoppingCart.Items.ToLookup(p => p.Product);

            return offer.Products.All(p => productsInShoppingCart.Contains(p) && shoppingCartLookUp[p].Single().Quantity >= 1);
        }

    }
}
