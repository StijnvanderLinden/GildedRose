using GildedRose.Console.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Models
{
    internal class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public Specialty Specialty { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + "\n" +
                "SellIn: " + SellIn + "\n" +
                "Quality: " + Quality + "\n" +
                "Specialty: " + Specialty + "\n";
        }

        public void UpdateQuality()
        {
            switch (Specialty)
            {
                case Specialty.COMMON:
                    DropQuality(this);
                    DropSellIn(this);
                    break;

                case Specialty.CHEESE:
                    DropQuality(this);
                    DropSellIn(this);
                    break;

                case Specialty.CONJURED:
                    DropQuality(this);
                    DropSellIn(this);
                    break;

                case Specialty.BACKSTAGE:
                    DropSellIn(this);
                    break;

                case Specialty.LEGENDARY:
                    break;
            }
        }

        public void DropQuality(Item item)
        {
            //if quality is 0, nothing to do here
            if (item.Quality == 0)
            {
                return;
            }

            int qualityDrop = 1;

            //check if item is conjured
            if(item.Specialty == Specialty.CONJURED)
            {
                qualityDrop *= 2;
            }

            //check if item is expired
            if(item.SellIn == 0)
            {
                qualityDrop *= 2;
            }

            //reduces the quality of item but not lower than 0
            item.Quality = Math.Max(item.Quality - qualityDrop, 0);

            return;
        }

        public void DropSellIn(Item item)
        {
            item.SellIn = Math.Max(item.SellIn - 1, 0);
        }
    }
}
