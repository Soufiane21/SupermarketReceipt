using SupermarketReceipt.Enums;
using System.Collections.Generic;

namespace SupermarketReceipt.Entities
{
    public class Offer
    {
      
        public Offer(SpecialOfferType offerType, Product product, double argument)
        {
            Products = new List<Product>
            { 
                product
            };
            OfferType = offerType;
            Argument = argument;
        }

        public Offer(SpecialOfferType offerType, List<Product> products, double argument)
        {
            OfferType = offerType;
            Products = products;
            Argument = argument;
        }

        public readonly List<Product> Products;
        public SpecialOfferType OfferType { get; }
        public double Argument { get; }
    }
}