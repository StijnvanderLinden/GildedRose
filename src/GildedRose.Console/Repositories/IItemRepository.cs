using GildedRose.Console.Models;
using System.Collections.Generic;

namespace GildedRose.Console.Repositories
{
    internal interface IItemRepository
    {
        List<Item> GetItems();
        void UpdateQuality(Item item);
        void AddQuality(Item item);
        void DropQuality(Item item, bool conjured);
        void DropSellIn(Item item);
    }
}
