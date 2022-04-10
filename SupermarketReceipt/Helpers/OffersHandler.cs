using SupermarketReceipt.Comparison;
using SupermarketReceipt.Entities;
using SupermarketReceipt.Enums;
using SupermarketReceipt.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketReceipt.Helpers
{
    public class OffersHandler
    {
        private ShoppingCart _shoppingCart;

        public OffersHandler(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
        }

        public void HandleOffers(Receipt receipt, IEnumerable<Offer> offers, ISupermarketCatalog catalog)
        {
            var productsWithOffers = _shoppingCart.Items.Where(p => offers.Where(o => o.Products.Contains(p.Product)).Any());

            foreach (var productQuantity in productsWithOffers.ToList())
            {
                var offer = offers.Where(o => o.Products.Contains(productQuantity.Product)).Single();
                var unitPrice = catalog.GetUnitPrice(productQuantity.Product);

                Discount discount = CalculateDiscount(productQuantity, offer, unitPrice, catalog);

                if (discount != null)
                    receipt.AddDiscount(discount);
            }
        }

        private Discount CalculateDiscount(ProductQuantity productQuantity, Offer offer, double unitPrice, ISupermarketCatalog catalog)
        {
            IDiscountStrategy discountStrategy = null;

            switch (offer.OfferType)
            {
                case SpecialOfferType.ThreeForTwo :
                    discountStrategy = new AmountXForAmountYDiscountStrategy(productQuantity, unitPrice, 3, 2);
                    break;
                case SpecialOfferType.PercentageDiscount:
                    discountStrategy = new PercentageDiscountStrategy(productQuantity, unitPrice, offer.Argument);
                    break;
                case SpecialOfferType.TwoForAmount :
                    discountStrategy = new AmountXForPriceYDiscountStrategy(productQuantity, unitPrice, 2, offer.Argument);
                    break;
                case SpecialOfferType.FiveForAmount :
                    discountStrategy = new AmountXForPriceYDiscountStrategy(productQuantity, unitPrice, 5, offer.Argument);
                    break;
                case SpecialOfferType.Bulk :
                    discountStrategy = new BulkDiscountStrategy(productQuantity, unitPrice, offer, _shoppingCart, catalog);
                    break;
            }

            return discountStrategy.GetDiscount();
        }
    }
}
