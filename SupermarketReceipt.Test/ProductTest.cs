using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SupermarketReceipt.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void ProductShouldHaveNameAndUnit()
        {
            // ARRANGE
            var productName = "milk";
            var productUnit = ProductUnit.Each;

            // ACT
            var product = new Product(productName, productUnit);

            // ASSERT
            product.Name.Should().Be(productName);
            product.Unit.Should().Be(productUnit);
        }

        [TestMethod]
        public void ProductWithSameNameAndUnitShouldBeEqual()
        {
            // ARRANGE
            var product1 = new Product("bread", ProductUnit.Each);
            var product2 = new Product("bread", ProductUnit.Each);

            // ACT & ASSERT
            product1.Should().Be(product2);
        }
    }
}
