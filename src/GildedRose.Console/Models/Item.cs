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

        public override string ToString()
        {
            return "Name: " + Name + "\n" + 
                "SellIn: " + SellIn + "\n" + 
                "Quality: " + Quality;
        }
    }
}
