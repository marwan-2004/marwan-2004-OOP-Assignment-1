using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(int Id, string Name, decimal Price, int Stock)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Stock = Stock;
        }
        public bool ReduceStock(int quantity)
        {
            if(quantity<=0 || Stock < quantity)
            {
                return false;
            }
            Stock -= quantity;
            return true;
        }

        public override string ToString()
        {
            return $"#{Id} {Name} price={Price:F2} stock={Stock} ";
        }
    }
}
