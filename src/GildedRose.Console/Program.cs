using GildedRose.Console.Models;
using GildedRose.Console.Enums;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    class Program
    {
        List<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Specialty = Specialty.COMMON},
                        new Item {Name = "Aged Brie", SellIn = 2, Quality = 0, Specialty = Specialty.CHEESE},
                        new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, Specialty = Specialty.COMMON},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, Specialty = Specialty.LEGENDARY},
                        new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20, Specialty = Specialty.BACKSTAGE},
                        new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Specialty = Specialty.CONJURED}
                    }

            };
            
            while(app.Items.Where(x => x.Quality > 0).Any())
            {
                foreach (Item item in app.Items)
                {
                    item.UpdateQuality();
                    System.Console.WriteLine(item);
                }
                System.Console.ReadKey();
            }

            
        }

        
    }
}
