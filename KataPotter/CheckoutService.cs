using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class CheckoutService
    {
        private const int SingleUnitPrice = 8;

        private readonly List<DiscountRule> _discountRules;

        public CheckoutService()
        {
            _discountRules = new List<DiscountRule>
            {
                new DiscountRule {Discount = 0.75, UniqueItems = 5},
                new DiscountRule {Discount = 0.80, UniqueItems = 4},
                new DiscountRule {Discount = 0.90, UniqueItems = 3},
                new DiscountRule {Discount = 0.95, UniqueItems = 2}
            };
        }

        public double CalculateTotal(List<Item> items)
        {
            if (items == null) return 0;
            var discountTotal = ApplyDiscounts(items);
            var residueTotal = CalculateRemainingCost(items);
            return discountTotal + residueTotal;
        }

        private double ApplyDiscounts(List<Item> items)
        {
            var runningTotal = 0.0;
            foreach (var discountRule in _discountRules)
            {
                while (IsDiscountAvailable(items, discountRule.UniqueItems))
                {
                    var cost = (SingleUnitPrice * discountRule.UniqueItems) * discountRule.Discount;
                    runningTotal = runningTotal + cost;
                    ReduceQuantities(items, discountRule.UniqueItems);
                }
            }
            return runningTotal;
        }

        private bool IsDiscountAvailable(IEnumerable<Item> items, int uniqueItems)
        {
            return items.Count(i => i.Quantity > 0) == uniqueItems;
        }

        private void ReduceQuantities(IEnumerable<Item> items, int uniqueItems)
        {
            var itemsToReduce = items.Where(i => i.Quantity > 0).ToList();
            for (var i = 0; i < uniqueItems; i++)
            {
                itemsToReduce[i].Quantity--;
            }
        }

        private double CalculateRemainingCost(IEnumerable<Item> items)
        {
            return items.Sum(i => i.Quantity) * SingleUnitPrice;
        }

    }
}
