using Xunit;
using GildedRose.Console.Repositories;
using GildedRose.Console.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        IItemRepository repo;
        List<Item> items;

        public TestAssemblyTests()
        {
            repo = new ItemRepository();
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

        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        [Fact]
        [Description("Get all items")]
        public void GetItems()
        {
            Assert.Equal(items.Count, repo.GetItems().Count);
        }

        [Fact]
        [Description("Increase quality of item")]
        public void IncreaseQuality()
        {
            repo.IncreaseQuality(items[1]);
            Assert.Equal(items[1].Quality, 1);
        }

        [Fact]
        [Description("Reduce quality of item")]
        public void ReduceQuality()
        {
            repo.ReduceQuality(items[5], true);
            Assert.Equal(items[5].Quality, 4);
        }

        [Fact]
        [Description("Reduce SellIn of item")]
        public void ReduceSellIn()
        {
            repo.ReduceSellIn(items[1]);
            Assert.Equal(items[1].SellIn, 1);
        }
    }
}