using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SupermarketReceipt.Test
{
    [TestClass]
    public class ReceiptTests
    {
        [TestMethod]
        public void AddProduct_ShouldAddProductToReceipt()
        {
            // ARRANGE
            var receipt = new Receipt();
            var product = new Product("apple", ProductUnit.Kilo);

            // ACT
            receipt.AddProduct(product, 2.5, 1.99, 4.975);

            // ASSERT
            using (new AssertionScope())
            {
                var items = receipt.GetItems();
                items.Count.Should().Be(1);
                items[0].Product.Should().Be(product);
                items[0].Quantity.Should().Be(2.5);
                items[0].Price.Should().Be(1.99);
                items[0].TotalPrice.Should().Be(4.975);
            }
        }

        [TestMethod]
        public void AddDiscount_ShouldAddDiscountToReceipt()
        {
            // ARRANGE
            var receipt = new Receipt();
            var product = new Product("toothbrush", ProductUnit.Each);
            var discount = new Discount(product, "10% discount", 0.99);

            // ACT
            receipt.AddDiscount(discount);

            // ASSERT
            using (new AssertionScope())
            {
                var discounts = receipt.GetDiscounts();
                discounts.Count.Should().Be(1);
                discounts[0].Product.Should().Be(product);
                discounts[0].Description.Should().Be("10% discount");
                discounts[0].DiscountAmount.Should().Be(0.99);
            }
        }

        [TestMethod]
        public void GetTotalPrice_ShouldCalculateCorrectTotal()
        {
            // ARRANGE
            var receipt = new Receipt();
            var apple = new Product("apple", ProductUnit.Kilo);
            var toothbrush = new Product("toothbrush", ProductUnit.Each);

            // ACT
            receipt.AddProduct(apple, 2.5, 1.99, 4.975);
            receipt.AddProduct(toothbrush, 1.0, 0.99, 0.99);

            // ASSERT
            receipt.GetTotalPrice().Should().Be(5.965);
        }

        [TestMethod]
        public void GetTotalPrice_ShouldApplyDiscounts()
        {
            // ARRANGE
            var receipt = new Receipt();
            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            var discount = new Discount(toothbrush, "10% discount", 0.099);

            // ACT
            receipt.AddProduct(toothbrush, 1.0, 0.99, 0.99);
            receipt.AddDiscount(discount);

            // ASSERT
            receipt.GetTotalPrice().Should().BeApproximately(0.891, 0.001);
        }

        [TestMethod]
        public void GetTotalPrice_ShouldReturnZeroForEmptyReceipt()
        {
            // ARRANGE
            var receipt = new Receipt();

            // ACT & ASSERT
            receipt.GetTotalPrice().Should().Be(0.0);
        }
    }
}