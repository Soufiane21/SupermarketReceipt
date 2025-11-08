using SupermarketReceipt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketReceipt
{
    public class Receipt
    {
        private readonly List<Discount> _discounts = new();
        private readonly List<ReceiptItem> _items = new();

        public double TotalPrice => CalculateTotalPrice();

        public void AddProduct(Product product, double quantity, double price, double totalPrice)
        {
            _items.Add(new ReceiptItem(product, quantity, price, totalPrice));
        }

        public IReadOnlyList<ReceiptItem> Items => _items.AsReadOnly();

        public void AddDiscount(Discount discount)
        {
            _discounts.Add(discount);
        }

        public IReadOnlyList<Discount> Discounts => _discounts.AsReadOnly();

        private double CalculateTotalPrice()
        {
            return Math.Round(_items.Sum(item => item.TotalPrice) - _discounts.Sum(discount => discount.DiscountAmount), 2);
        }
    }
}
