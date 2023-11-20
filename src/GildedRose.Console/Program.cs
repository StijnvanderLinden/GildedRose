using GildedRose.Console.Models;
using GildedRose.Console.Repositories;
using System.Linq;

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

            while (app.repo.GetItems().Where(x => x.Quality > 0).Any())
            {
                foreach (Item item in app.repo.GetItems())
                {
                    app.repo.UpdateQuality(item);
                    System.Console.WriteLine(item);
                }
                System.Console.ReadKey();
            }
        }
    }
}
