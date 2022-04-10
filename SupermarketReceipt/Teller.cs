using SupermarketReceipt.Entities;
using SupermarketReceipt.Enums;
using SupermarketReceipt.Helpers;
using System.Collections.Generic;

namespace SupermarketReceipt
{
    public class Teller
    {
        private readonly ISupermarketCatalog _catalog;
        private readonly List<Offer> _offers;

        public Teller(ISupermarketCatalog catalog)
        {
            _catalog = catalog;
            _offers = new List<Offer>();   
        }

        public void AddSpecialOffer(SpecialOfferType offerType, Product product, double argument)
        {
            _offers.Add(new Offer(offerType, product, argument));
        }

        public void AddSpecialOffer(SpecialOfferType offerType, List<Product> products, double argument)
        {
            _offers.Add(new Offer(offerType, products, argument));
        }


        public Receipt ChecksOutArticlesFrom(ShoppingCart theCart)
        {
            var receipt = new Receipt();
            var productQuantities = theCart.GetItems();

            foreach (var pq in productQuantities)
            {
                var p = pq.Product;
                var quantity = pq.Quantity;
                var unitPrice = _catalog.GetUnitPrice(p);
                var price = quantity * unitPrice;
                receipt.AddProduct(p, quantity, unitPrice, price);
            }

            var offersHandler = new OffersHandler(theCart);
            offersHandler.HandleOffers(receipt, _offers, _catalog);

            return receipt;
        }
    }
}