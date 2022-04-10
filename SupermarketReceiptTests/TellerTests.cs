using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketReceipt;
using SupermarketReceipt.Entities;
using SupermarketReceipt.Enums;
using System.Collections.Generic;

namespace SupermarketReceiptTests
{
    [TestClass]
    public class TellerTests
    {

        [TestMethod]
        public void GivenApples_WhenTenPercentDiscount_DiscountShouldBeApplied()
        {
            // ARRANGE
            var catalog = new FakeCatalog();
            var cart = new ShoppingCart();
            var _sut = new Teller(catalog);

            var apples = new Product("apples", ProductUnit.Kilo);

            catalog.AddProduct(apples, 1.99);

            cart.AddItemQuantity(apples, 2.5);

            _sut.AddSpecialOffer(SpecialOfferType.PercentageDiscount, apples, 10);

            // ACT
            var receipt = _sut.ChecksOutArticlesFrom(cart);

            // ASSERT
            using (new AssertionScope())
            {
                receipt.GetTotalPrice().Should().Be(4.48);
                receipt.GetItems().Count.Should().Be(1);
                var receiptItem = receipt.GetItems()[0];
                receiptItem.Product.Should().Be(apples);
                receiptItem.Price.Should().Be(1.99);
                receiptItem.TotalPrice.Should().Be(2.5 * 1.99);
                receiptItem.Quantity.Should().Be(2.5);
            }
        }

        [TestMethod]
        public void GivenApples_WhenTwentyPercentDiscount_DiscountShouldBeApplied()
        {
            // ARRANGE
            var catalog = new FakeCatalog();
            var cart = new ShoppingCart();
            var _sut = new Teller(catalog);

            var apples = new Product("apples", ProductUnit.Kilo);

            catalog.AddProduct(apples, 1.99);

            cart.AddItemQuantity(apples, 2.5);

            _sut.AddSpecialOffer(SpecialOfferType.PercentageDiscount, apples, 20);

            // ACT
            var receipt = _sut.ChecksOutArticlesFrom(cart);

            // ASSERT
            using (new AssertionScope())
            {
                receipt.GetTotalPrice().Should().Be(3.98);
                receipt.GetItems().Count.Should().Be(1);
                var receiptItem = receipt.GetItems()[0];
                receiptItem.Product.Should().Be(apples);
                receiptItem.Price.Should().Be(1.99);
                receiptItem.TotalPrice.Should().Be(4.975);
                receiptItem.Quantity.Should().Be(2.5);
            }
        }

        [TestMethod]
        public void GivenToothbrush_TwoForOne_DiscountShouldBeApplied()
        {
            // ARRANGE
            var catalog = new FakeCatalog();
            var cart = new ShoppingCart();
            var _sut = new Teller(catalog);

            var toothbrush = new Product("toothbrush", ProductUnit.Each);

            catalog.AddProduct(toothbrush, 0.99);

            cart.AddItemQuantity(toothbrush, 2);

            _sut.AddSpecialOffer(SpecialOfferType.TwoForAmount, toothbrush, 1);

            // ACT
            var receipt = _sut.ChecksOutArticlesFrom(cart);

            // ASSERT
            using (new AssertionScope())
            {
                receipt.GetTotalPrice().Should().Be(1.00);
                receipt.GetItems().Count.Should().Be(1);
                var receiptItem = receipt.GetItems()[0];
                receiptItem.Product.Should().Be(toothbrush);
                receiptItem.Price.Should().Be(0.99);
                receiptItem.TotalPrice.Should().Be(2 * 0.99);
                receiptItem.Quantity.Should().Be(2);
            }
        }

        [TestMethod]
        public void GivenToothbrush_ThreeForTwo_DiscountShouldBeApplied()
        {
            // ARRANGE
            var catalog = new FakeCatalog();
            var cart = new ShoppingCart();
            var _sut = new Teller(catalog);

            var toothbrush = new Product("toothbrush", ProductUnit.Each);

            catalog.AddProduct(toothbrush, 0.99);

            cart.AddItemQuantity(toothbrush, 3);

            _sut.AddSpecialOffer(SpecialOfferType.ThreeForTwo, toothbrush, 0);

            // ACT
            var receipt = _sut.ChecksOutArticlesFrom(cart);

            // ASSERT
            using (new AssertionScope())
            {
                receipt.GetTotalPrice().Should().Be(1.98);
                receipt.GetItems().Count.Should().Be(1);
                var receiptItem = receipt.GetItems()[0];
                receiptItem.Product.Should().Be(toothbrush);
                receiptItem.Price.Should().Be(0.99);
                receiptItem.TotalPrice.Should().Be(2.9699999999999998);
                receiptItem.Quantity.Should().Be(3);
            }
        }

        [TestMethod]
        public void GivenToothbrush_FiveForOne_DiscountShouldBeApplied()
        {
            // ARRANGE
            var catalog = new FakeCatalog();
            var cart = new ShoppingCart();
            var _sut = new Teller(catalog);

            var toothbrush = new Product("toothbrush", ProductUnit.Each);

            catalog.AddProduct(toothbrush, 1.49);

            cart.AddItemQuantity(toothbrush, 5);

            _sut.AddSpecialOffer(SpecialOfferType.FiveForAmount, toothbrush, 1.49);

            // ACT
            var receipt = _sut.ChecksOutArticlesFrom(cart);

            // ASSERT
            using (new AssertionScope())
            {
                receipt.GetTotalPrice().Should().Be(1.49);
                receipt.GetItems().Count.Should().Be(1);
                var receiptItem = receipt.GetItems()[0];
                receiptItem.Product.Should().Be(toothbrush);
                receiptItem.Price.Should().Be(1.49);
                receiptItem.TotalPrice.Should().Be(7.45);
                receiptItem.Quantity.Should().Be(5);
            }
        }


        [TestMethod]
        public void GivenCherryTomatos_TwoForFixedPrice_DiscountShouldBeApplied()
        {
            // ARRANGE
            var catalog = new FakeCatalog();
            var cart = new ShoppingCart();
            var _sut = new Teller(catalog);

            var cherrytomatos = new Product("cherrytomatos", ProductUnit.Each);

            catalog.AddProduct(cherrytomatos, 0.69);

            cart.AddItemQuantity(cherrytomatos, 2);

            _sut.AddSpecialOffer(SpecialOfferType.TwoForAmount, cherrytomatos, 0.99);

            // ACT
            var receipt = _sut.ChecksOutArticlesFrom(cart);

            // ASSERT
            using (new AssertionScope())
            {
                receipt.GetTotalPrice().Should().Be(0.99);
                receipt.GetItems().Count.Should().Be(1);
                var receiptItem = receipt.GetItems()[0];
                receiptItem.Product.Should().Be(cherrytomatos);
                receiptItem.Price.Should().Be(0.69);
                receiptItem.TotalPrice.Should().Be(1.38);
                receiptItem.Quantity.Should().Be(2);
            }
        }

        [TestMethod]
        public void Bulk10Percent_1Toothbrush1ToothPaste_DiscountShouldBeApplied()
        {
            // ARRANGE
            var catalog = new FakeCatalog();
            var cart = new ShoppingCart();
            var _sut = new Teller(catalog);


            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            var toothpaste = new Product("toothpaste", ProductUnit.Each);

            catalog.AddProduct(toothbrush, 0.99);
            catalog.AddProduct(toothpaste, 1.79);

            cart.AddItemQuantity(toothbrush, 1);
            cart.AddItemQuantity(toothpaste, 1);

            _sut.AddSpecialOffer(SpecialOfferType.Bulk, new List<Product> { toothpaste, toothbrush }, 10);

            // ACT
            var receipt = _sut.ChecksOutArticlesFrom(cart);

            // ASSERT
            using (new AssertionScope())
            {
                receipt.GetTotalPrice().Should().Be(2.50);
            }
        }

        [TestMethod]
        public void Bulk10Percent_2Toothbrush1ToothPaste_DiscountShouldBeAppliedOnce()
        {
            // ARRANGE
            var catalog = new FakeCatalog();
            var cart = new ShoppingCart();
            var _sut = new Teller(catalog);


            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            var toothpaste = new Product("toothpaste", ProductUnit.Each);

            catalog.AddProduct(toothbrush, 0.99);
            catalog.AddProduct(toothpaste, 1.79);

            cart.AddItemQuantity(toothbrush, 2);
            cart.AddItemQuantity(toothpaste, 1);

            _sut.AddSpecialOffer(SpecialOfferType.Bulk, new List<Product> { toothpaste, toothbrush }, 10);

            // ACT
            var receipt = _sut.ChecksOutArticlesFrom(cart);

            // ASSERT
            using (new AssertionScope())
            {
                receipt.GetTotalPrice().Should().Be(3.49);
            }
        }

        [TestMethod]
        public void Bulk10Percent_5Toothbrush5ToothPaste_DiscountShouldBeAppliedOnce()
        {
            // ARRANGE
            var catalog = new FakeCatalog();
            var cart = new ShoppingCart();
            var _sut = new Teller(catalog);


            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            var toothpaste = new Product("toothpaste", ProductUnit.Each);

            catalog.AddProduct(toothbrush, 0.99);
            catalog.AddProduct(toothpaste, 1.79);

            cart.AddItemQuantity(toothbrush, 7);
            cart.AddItemQuantity(toothpaste, 4);

            _sut.AddSpecialOffer(SpecialOfferType.Bulk, new List<Product> { toothpaste, toothbrush }, 10);

            // ACT
            var receipt = _sut.ChecksOutArticlesFrom(cart);

            // ASSERT
            using (new AssertionScope())
            {
                receipt.GetTotalPrice().Should().Be(12.98);
                receipt.GetItems().Count.Should().Be(2);
                var receiptItem = receipt.GetItems()[0];
                receiptItem.Quantity.Should().Be(7);
                receiptItem = receipt.GetItems()[1];
                receiptItem.Quantity.Should().Be(4);
            }
        }

    }
}