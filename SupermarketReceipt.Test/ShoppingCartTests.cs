using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SupermarketReceipt.Test
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void AddItemQuantity_ShouldAddSingleItem()
        {
            // ARRANGE
            var cart = new ShoppingCart();
            var product = new Product("apple", ProductUnit.Kilo);

            // ACT
            cart.AddItemQuantity(product, 2.5);

            // ASSERT
            using (new AssertionScope())
            {
                var items = cart.GetItems();
                items.Count.Should().Be(1);
                items[0].Product.Should().Be(product);
                items[0].Quantity.Should().Be(2.5);
            }
        }

        [TestMethod]
        public void AddItemQuantity_ShouldAddMultipleItems()
        {
            // ARRANGE
            var cart = new ShoppingCart();
            var apple = new Product("apple", ProductUnit.Kilo);
            var banana = new Product("banana", ProductUnit.Kilo);
            var toothbrush = new Product("toothbrush", ProductUnit.Each);

            // ACT
            cart.AddItemQuantity(apple, 2.5);
            cart.AddItemQuantity(banana, 1.0);
            cart.AddItemQuantity(toothbrush, 3.0);

            // ASSERT
            using (new AssertionScope())
            {
                var items = cart.GetItems();
                items.Count.Should().Be(3);
            }
        }

        [TestMethod]
        public void AddItemQuantity_ShouldAccumulateQuantityForSameProduct()
        {
            // ARRANGE
            var cart = new ShoppingCart();
            var apple = new Product("apple", ProductUnit.Kilo);

            // ACT
            cart.AddItemQuantity(apple, 2.0);
            cart.AddItemQuantity(apple, 1.5);

            // ASSERT
            using (new AssertionScope())
            {
                var items = cart.GetItems();
                items.Count.Should().Be(1);
                items[0].Quantity.Should().Be(3.5);
            }
        }

        [TestMethod]
        public void AddItem_ShouldAddSingleQuantity()
        {
            // ARRANGE
            var cart = new ShoppingCart();
            var toothbrush = new Product("toothbrush", ProductUnit.Each);

            // ACT
            cart.AddItem(toothbrush);

            // ASSERT
            using (new AssertionScope())
            {
                var items = cart.GetItems();
                items.Count.Should().Be(1);
                items[0].Quantity.Should().Be(1.0);
            }
        }
    }
}