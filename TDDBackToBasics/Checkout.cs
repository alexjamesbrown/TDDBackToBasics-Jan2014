using System.Collections.Generic;
using System.Linq;

namespace MyShop
{
    public class Checkout
    {
        public Checkout()
        {
            Items = new List<Item>();
        }

        public int ScanItem(Item item)
        {
            Items.Add(item);
            return calculatePrice(item);
        }

        private static int calculatePrice(Item item)
        {
            var items = new Dictionary<string, int>
            {
                {"A", 50},
                {"B", 30},
                {"C", 20},
                {"D", 15}
            };

            return items[item.Name];
        }

        public IList<Item> Items { get; set; }

        public int Total()
        {
            var total = Items.Sum(item => calculatePrice(item));

            return total - (NumberOfGroups("A", 3) * 20) - (NumberOfGroups("B", 2) * 15);
        }

        private int NumberOfGroups(string name, int numItems)
        {
            return (Items.Count(x => x.Name.Equals(name)) / numItems);
        }
    }
}