using System.Collections.Generic;
using KataPotter;
using NUnit.Framework;

namespace KataPotterTests
{
   [TestFixture]
    public class CheckoutServiceTests
    {

        [Test]
        public void BasketWithNullItems()
        {
            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(null);
            Assert.AreEqual(0, total);
        }

        [Test]
        public void BasketWith0Items()
        {
            var basket = new List<Item>();
            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(0, total);
        }

        [Test]
        public void BasketWith1Item()
        {
            var basket = new List<Item> {new Item {Sku = "Book1", Quantity = 1}};
            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(8, total);
        }

        [Test]
        public void BasketWith2OfTheSameItem()
        {
            var basket = new List<Item> { new Item { Sku = "Book1", Quantity = 2 } };
            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(16, total);
        }

        [Test]
        public void BasketWith3OfTheSameItem()
        {
            var basket = new List<Item> { new Item { Sku = "Book1", Quantity = 3 } };
            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(24, total);
        }

        [Test]
        public void BasketWith2DifferentItems()
        {
            var basket = new List<Item> { new Item { Sku = "Book1", Quantity = 1 }, new Item { Sku = "Book2", Quantity = 1 } };
            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(15.2, total);
        }

        [Test]
        public void BasketWith5DifferentItemsGives25PercentDiscount()
        {
            var basket = new List<Item>
            {
                new Item { Sku = "Book1", Quantity = 1 },
                new Item { Sku = "Book2", Quantity = 1 },
                new Item { Sku = "Book3", Quantity = 1 },
                new Item { Sku = "Book4", Quantity = 1 },
                new Item { Sku = "Book5", Quantity = 1 }
            };

            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(30, total);
        }

        [Test]
        public void BasketWith4DifferentItemsGives20PercentDiscount()
        {
            var basket = new List<Item>
            {
                new Item { Sku = "Book1", Quantity = 1 },
                new Item { Sku = "Book2", Quantity = 1 },
                new Item { Sku = "Book3", Quantity = 1 },
                new Item { Sku = "Book4", Quantity = 1 }
            };

            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(25.6, total);
        }

        [Test]
        public void BasketWith3DifferentItemsGives10PercentDiscount()
        {
            var basket = new List<Item>
            {
                new Item { Sku = "Book1", Quantity = 1 },
                new Item { Sku = "Book2", Quantity = 1 },
                new Item { Sku = "Book3", Quantity = 1 }
            };

            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(21.6, total);
        }

        [Test]
        public void BasketWith2DifferentItemsGives5PercentDiscount()
        {
            var basket = new List<Item>
            {
                new Item { Sku = "Book1", Quantity = 1 },
                new Item { Sku = "Book2", Quantity = 1 }
            };

            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(15.2, total);
        }

        [Test]
        public void BasketWith2QuantityOf2Items()
        {
            var basket = new List<Item>
            {
                new Item { Sku = "Book1", Quantity = 2 },
                new Item { Sku = "Book2", Quantity = 2 },
            };

            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(30.4, total);
        }
        
        [Test]
        public void BasketWithTwoItemsQuantity2AndOne()
        {
            var basket = new List<Item>
            {
                new Item { Sku = "Book1", Quantity = 2 },
                new Item { Sku = "Book2", Quantity = 1 },
            };

            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(23.2, total);
        }

        [Test]
        public void AttemptAtAnswer()
        {
            var basket = new List<Item>
            {
                new Item { Sku = "Book1", Quantity = 2 },
                new Item { Sku = "Book2", Quantity = 2 },
                new Item { Sku = "Book3", Quantity = 2 },
                new Item { Sku = "Book4", Quantity = 1 },
                new Item { Sku = "Book5", Quantity = 1 }
            };

            var checkoutService = new CheckoutService();
            var total = checkoutService.CalculateTotal(basket);
            Assert.AreEqual(51.60, total);
        }

    }
}
