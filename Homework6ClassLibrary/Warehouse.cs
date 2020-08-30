using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6ClassLibrary
{
    public class Warehouse
    {
        public static List<Item> items = new List<Item>();

        public static int ItemsCapacity
        {
            get
            {
                return items.Count;
            }
        }

        public static void WriteOff()
        {
            foreach(var item in items)
            {
                if(item.GetExpirationDate() >= DateTime.Now)
                {
                    items.Remove(item);
                }
            }
        }

        public static void LoadItems()
        {
            string name;
            double price;
            int daysToExpire;
            DateTime deliveryDate;
            StreamReader sr = new StreamReader("data.txt");
            int capacity = int.Parse(sr.ReadLine());
            for(int i = 0; i < capacity; i++)
            {
                name = sr.ReadLine();
                price = double.Parse(sr.ReadLine());
                daysToExpire = int.Parse(sr.ReadLine());
                deliveryDate = DateTime.Parse(sr.ReadLine());
                items.Add(new Item(name, price, deliveryDate, daysToExpire));
            }
            sr.Close();
        }

        public static void SaveItems()
        {
            StreamWriter sw = new StreamWriter("data.txt");
            sw.WriteLine(ItemsCapacity);
            foreach(var item in items)
            {
                sw.WriteLine(item.Name);
                sw.WriteLine(item.Price);
                sw.WriteLine(item.DaysToExpire);
                sw.WriteLine(item.DeliveryDate);
            }
            sw.Close();
        }
    }
}
