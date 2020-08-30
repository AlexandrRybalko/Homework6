using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6ClassLibrary
{
    public partial class Item
    {
        public string Name { get; }
        public double Price { get; set; }
        public DateTime DeliveryDate { get; }

        public Item(string name, double price, DateTime deliveryDate, int daysToExpire)
        {
            Name = name;
            Price = price;
            DeliveryDate = deliveryDate;
            DaysToExpire = daysToExpire;
        }

        public DateTime GetExpirationDate()
        {
            return DeliveryDate.AddDays(DaysToExpire);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, Delivery date: {DeliveryDate}, Days until expiration: {DaysToExpire}, Expiration date: {GetExpirationDate()}";
        }
    }
}
