using System;
using System.Collections.Generic;
using System.Linq;

namespace Fibonacci
{
    class Program
    {
        static void Main()
        {
            var initialInput = Console.ReadLine();
            var initialInputArray = initialInput.Split(' ');
            var lootItems = new List<LootItem>();
            var capacity = int.Parse(initialInputArray[1]);
            for(var i = 0; i < int.Parse(initialInputArray[0]); i++)
            {
                var input = Console.ReadLine();
                var inputArray = input.Split(' ');
                lootItems.Add(new LootItem{TotalValue = int.Parse(inputArray[0]), Weight = int.Parse(inputArray[1]), Value = (double)int.Parse(inputArray[0])/int.Parse(inputArray[1]) });                
            }
            lootItems.Sort();
            var result = CountMaxLoot(lootItems, capacity);
            Console.WriteLine($"{result:F4}");
        }

        static double CountMaxLoot(List<LootItem> loot, int currentCapacity)
        {
            if (loot.Any() && currentCapacity > 0)
            {
                double lootValue;
                var lootItem = loot.Last();
                if (lootItem.Weight <= currentCapacity)
                {
                    currentCapacity -= lootItem.Weight;
                    lootValue = lootItem.TotalValue;
                }
                else
                {
                    var fraction = (double)currentCapacity / (lootItem.Weight);
                    lootValue = lootItem.TotalValue * fraction;
                    currentCapacity = 0;
                }
                loot.Remove(lootItem);
                return lootValue + CountMaxLoot(loot, currentCapacity);
            }
            return 0;
        }

        class LootItem : IComparable<LootItem>
        {
            public int TotalValue {get;set;}
            public int Weight {get;set;}
            public double Value {get;set;}

            public int CompareTo(LootItem other)
            {
                if (other == null) return 1;
                return Value.CompareTo(other.Value);
            }
        }
    }
}