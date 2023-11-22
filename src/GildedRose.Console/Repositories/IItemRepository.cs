using GildedRose.Console.Models;
using System.Collections.Generic;

namespace GildedRose.Console.Repositories
{
    public interface IItemRepository
    {
        List<Item> GetItems();
        void Update(Item item);
        void IncreaseQuality(Item item);
        void ReduceQuality(Item item, bool conjured);
        void ReduceSellIn(Item item);
    }
}
