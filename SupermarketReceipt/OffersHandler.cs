using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupermarketReceipt
{
    public class OffersHandler
    {
        private ShoppingCart _shoppingCart;

        public OffersHandler(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
        }

        public void HandleOffers(Receipt receipt, Dictionary<Product, Offer> offers, SupermarketCatalog catalog)
        {
            var productsWithOffers = _shoppingCart.ProductQuantities.Keys.Where(p => offers.ContainsKey(p));

            foreach (var product in productsWithOffers)
            {
                var offer = offers[product];
                var unitPrice = catalog.GetUnitPrice(product);

                Discount discount = CalculateDiscount(product, offer, unitPrice);

                if (discount != null)
                    receipt.AddDiscount(discount);
            }
        }

        private Discount CalculateDiscount(Product product, Offer offer, double unitPrice)
        {
            var quantity = _shoppingCart.ProductQuantities[product];

            switch (offer.OfferType)
            {
                case SpecialOfferType.ThreeForTwo when quantity >= 3:
                    return new Discount(product, "3 for 2", unitPrice);
                case SpecialOfferType.TenPercentDiscount:
                    return new Discount(product, offer.Argument + "% off", (quantity * unitPrice) * offer.Argument);
                case SpecialOfferType.TwoForAmount when quantity >= 2:
                    return new Discount(product, "2 for " + offer.Argument, GetDiscountQuantityForAmount(quantity, offer, unitPrice));
                case SpecialOfferType.FiveForAmount when quantity >= 5:
                    return new Discount(product, "5 for " + offer.Argument, GetDiscountQuantityForAmount(quantity, offer, unitPrice));
            }

            return null;
        }

        private static double GetDiscountQuantityForAmount(double quantity, Offer offer, double unitPrice)
        {
            return (unitPrice * quantity) - offer.Argument;
        }
    }
}
