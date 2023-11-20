using GildedRose.Console.Models;
using System;
using System.Collections.Generic;

namespace GildedRose.Console.Repositories
{
    public class ItemRepository : IItemRepository
    {
        List<Item> items;
        public ItemRepository()
        {
            items = new List<Item>
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                        new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                        new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                        new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                    };
        }
        public void IncreaseQuality(Item item)
        {
            if (item.SellIn == 0 && item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = 0;
                return;
            }

            if (item.Quality == 50)
            {
                return;
            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn <= 5)
                {
                    item.Quality += 3;
                    return;
                }
                if (item.SellIn <= 10)
                {
                    item.Quality += 2;
                    return;
                }
            }
            item.Quality += 1;
        }

        public void ReduceQuality(Item item, bool conjured)
        {
            //if quality is 0, nothing to do here
            if (item.Quality == 0)
            {
                return;
            }

            int qualityDrop = 1;

            //check if item is conjured
            if (conjured)
            {
                qualityDrop *= 2;
            }

            //check if item is expired
            if (item.SellIn == 0)
            {
                qualityDrop *= 2;
            }

            //reduces the quality of item but not lower than 0
            item.Quality = Math.Max(item.Quality - qualityDrop, 0);

            return;
        }

        public void ReduceSellIn(Item item)
        {
            item.SellIn = Math.Max(item.SellIn - 1, 0);
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public void UpdateQuality(Item item)
        {
            switch (item.Name)
            {
                case "+5 Dexterity Vest":
                    ReduceSellIn(item);
                    ReduceQuality(item, false);
                    break;

                case "Elixir of the Mongoose":
                    ReduceSellIn(item);
                    ReduceQuality(item, false);
                    break;

                case "Aged Brie":
                    ReduceSellIn(item);
                    IncreaseQuality(item);
                    break;

                case "Conjured Mana Cake":
                    ReduceSellIn(item);
                    ReduceQuality(item, true);
                    break;

                case "Backstage passes to a TAFKAL80ETC concert":
                    ReduceSellIn(item);
                    IncreaseQuality(item);
                    break;
            }
        }
    }
}
