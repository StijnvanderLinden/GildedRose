using GildedRose.Console.Models;
using GildedRose.Console.Enums;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GildedRose.Console
{
    class Program
    {
        List<Item> Items;
        static void Main(string[] args)
        {
            var app = new Program()
            {
                Items = new List<Item>
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                        new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                        new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                        new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                    }

            };

            foreach (Item item in app.Items)
            {
                System.Console.WriteLine(item);
            }

            System.Console.ReadKey();

            while (app.Items.Where(x => x.Quality > 0).Any())
            {
                foreach (Item item in app.Items)
                {
                    UpdateQuality(item);
                    System.Console.WriteLine(item);
                }
                System.Console.ReadKey();
            }
        }

        public static void UpdateQuality(Item item)
        {
            switch (item.Name)
            {
                case "+5 Dexterity Vest":
                    DropSellIn(item);
                    DropQuality(item, false);
                    break;

                case "Elixir of the Mongoose":
                    DropSellIn(item);
                    DropQuality(item, false);
                    break;

                case "Aged Brie":
                    DropSellIn(item);
                    AddQuality(item);
                    break;

                case "Conjured Mana Cake":
                    DropSellIn(item);
                    DropQuality(item, true);
                    break;

                case "Backstage passes to a TAFKAL80ETC concert":
                    DropSellIn(item);
                    AddQuality(item);
                    break;
            }
        }

        public static void AddQuality(Item item)
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

        public static void DropQuality(Item item, bool conjured)
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

        public static void DropSellIn(Item item)
        {
            item.SellIn = Math.Max(item.SellIn - 1, 0);
        }


    }
}
