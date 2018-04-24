using InventoryManager.DataAccess;
using InventoryManager.Domain.Interfaces;
using InventoryManager.Domain.Models;
using InventoryManager.Logic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManager.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var itemStore = new List<Item>();
            var itemDataAccess = new ItemDataAccess(itemStore);

            var itemQueries = new ItemQueries(itemDataAccess);
            var itemCommands = new ItemCommands(itemDataAccess);

            Console.WriteLine("Inventory Manager");
            Console.WriteLine("\nAvailable commands:");
            Console.WriteLine("S{Amount} - Sell item stock");
            Console.WriteLine("I{Amount} - Add item");
            Console.WriteLine("L - Show current balance");
            OutputItemStock(itemQueries.GetItemsAsync().Result.Count);

            bool operating = false;

            while (!operating)
            {
                Console.WriteLine("\nChoose an operation");
                string command = Console.ReadLine();

                if (command.ToLower().Contains("s"))
                {
                    if (int.TryParse(command.Substring(1), out int result))
                    {
                        Task.Run(() => itemCommands.PopItemsAsync(result)).Wait();
                        OutputItemStock(itemQueries.GetItemsAsync().Result.Count);
                    }
                }

                if (command.ToLower().Contains("i"))
                {
                    if (int.TryParse(command.Substring(1), out int result))
                    {
                        var items = new List<Item>();
                        for (int i = 0; i < result; i++)
                        {
                            items.Add(new Item() { Id = Guid.NewGuid() });
                        }

                        Task.Run(() => itemCommands.AddItemRangeAsync(items)).Wait();
                        OutputItemStock(itemQueries.GetItemsAsync().Result.Count);
                    }
                }

                if (command.ToLower().Contains("l"))
                {
                    OutputItemStock(itemQueries.GetItemsAsync().Result.Count);
                }
            }
           
        }

        static void OutputItemStock(int stock)
        {
            Console.WriteLine($"\nCurrent item stock: {stock}");

        }

    }
}
