using GildedRose.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
