using GildedRose.Console.Models;
using GildedRose.Console.Repositories;

namespace GildedRose.Console
{
    class Program
    {
        IItemRepository repo;
        static void Main(string[] args)
        {
            var app = new Program()
            {
                repo = new ItemRepository()
            };

            foreach (Item item in app.repo.GetItems())
            {
                System.Console.WriteLine(item);
            }

            System.Console.ReadKey();

            foreach (Item item in app.repo.GetItems())
            {
                app.repo.UpdateQuality(item);
                System.Console.WriteLine(item);
            }
            System.Console.ReadKey();
        }
    }
}
