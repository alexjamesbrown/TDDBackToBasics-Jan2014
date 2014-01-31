using System.Linq;
using MyShop;
using NUnit.Framework;

namespace tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private Checkout checkout;

        [SetUp]
        public void BeforeEach()
        {
            checkout = new Checkout();
        }

        [Test]
        public void item_a_has_a_price_of_50()
        {
            var item = new Item()
            {
                Name = "A"
            };

            var result = checkout.ScanItem(item);

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void item_b_has_a_price_of_30()
        {
            var item = new Item()
            {
                Name = "B"
            };

            var result = checkout.ScanItem(item);

            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void item_c_has_a_price_of_20()
        {
            var item = new Item()
            {
                Name = "C"
            };

            var result = checkout.ScanItem(item);

            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void item_d_has_a_price_of_15()
        {
            var item = new Item()
            {
                Name = "D"
            };

            var result = checkout.ScanItem(item);

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void items_contains_scanned_items()
        {
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "B" });

            Assert.That(checkout.Items.Any(x => x.Name.Equals("A")));
            Assert.That(checkout.Items.Any(x => x.Name.Equals("B")));
        }

        [Test]
        public void total_is_80_when_a_and_b_are_added()
        {
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "B" });

            var result = checkout.Total();

            Assert.That(result, Is.EqualTo(80));
        }

        [Test]
        public void total_is_35_when_c_and_d_are_added()
        {
            checkout.ScanItem(new Item { Name = "C" });
            checkout.ScanItem(new Item { Name = "D" });

            var result = checkout.Total();

            Assert.That(result, Is.EqualTo(35));
        }

        [Test]
        public void total_is_130_when_three_a_are_added()
        {
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "A" });

            var result = checkout.Total();

            Assert.That(result, Is.EqualTo(130));
        }

        [Test]
        public void total_is_210_when_four_a_and_b_are_added()
        {
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "B" });

            var result = checkout.Total();

            Assert.That(result, Is.EqualTo(210));
        }

        [Test]
        public void total_is_260_when_six_a_are_added()
        {
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "A" });
            checkout.ScanItem(new Item { Name = "A" });

            var result = checkout.Total();

            Assert.That(result, Is.EqualTo(260));
        }

        [Test]
        public void total_is_45_when_two_b_are_added()
        {
            checkout.ScanItem(new Item { Name = "B" });
            checkout.ScanItem(new Item { Name = "B" });

            var result = checkout.Total();

            Assert.That(result, Is.EqualTo(45));
        }
    }
}