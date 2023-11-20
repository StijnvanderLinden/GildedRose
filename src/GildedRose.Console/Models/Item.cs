namespace GildedRose.Console.Models
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + "\n" +
                "SellIn: " + SellIn + "\n" +
                "Quality: " + Quality + "\n";
        }
    }
}
