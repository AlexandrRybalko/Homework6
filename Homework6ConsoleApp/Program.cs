using Homework6ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse.LoadItems();
            string name;
            double price;
            int daysToExpire;
            while (true)
            {
                Console.WriteLine("Press any key to add item, press <escape> to quit. Press <i> for info");
                ConsoleKeyInfo p = Console.ReadKey();
                if (p.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (p.Key == ConsoleKey.I)
                {
                    foreach (var i in Warehouse.items)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine($"Warehouse capacity: {Warehouse.ItemsCapacity}");
                }
                else
                {
                    Console.WriteLine("Enter item name");
                    name = Console.ReadLine();

                    Console.WriteLine("Enter item price");
                    Double.TryParse(Console.ReadLine(), out price);

                    Console.WriteLine("Enter the date of delivery(yyyy/mm/dd):");
                    string[] date = Console.ReadLine().Split('/');
                    DateTime deliveryDate = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));

                    Console.WriteLine("Enter the number of days to expire");
                    daysToExpire = int.Parse(Console.ReadLine());

                    Warehouse.items.Add(new Item(name, price, deliveryDate, daysToExpire));
                }
            }
            Warehouse.SaveItems();
        }
    }
}
