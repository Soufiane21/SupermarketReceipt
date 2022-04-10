using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarketReceipt.Entities
{
    public class ProductQuantity
    {
        public ProductQuantity(Product product, double quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }
        public double Quantity { get; set; }
    }
}
