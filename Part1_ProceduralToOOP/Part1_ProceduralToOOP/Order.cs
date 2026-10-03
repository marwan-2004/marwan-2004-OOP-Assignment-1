using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class Order
    {
        private readonly List<OrderLine> _lines = new();

        public int Id { get; }
        public Customer Customer { get; }
        public string Date { get; }
        public bool IsPaid { get; private set; }
        public IReadOnlyList<OrderLine> Lines => _lines.AsReadOnly();

        public Order(int id, Customer customer, string date)
        {
            Id = id;
            Customer = customer;
            Date = date;
            IsPaid = false;
        }

        public bool AddLine(Product product, int quantity)
        {
            if (IsPaid)
            {
                Console.WriteLine("ERROR: cannot change a paid order.");
                return false;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("ERROR: quantity must be positive.");
                return false;
            }

            if (!product.ReduceStock(quantity))
            {
                Console.WriteLine($"ERROR: not enough stock for product #{product.Id}.");
                return false;
            }

            _lines.Add(new OrderLine(product, quantity));
            return true;
        }

        public decimal CalculateTotal()
        {
            decimal total = _lines.Sum(line => line.TotalPrice);

            if (Customer.IsVip)
                total *= 0.90m; 

            return total;
        }

        public bool MarkAsPaid()
        {
            if (_lines.Count == 0)
            {
                Console.WriteLine("ERROR: cannot pay an empty order.");
                return false;
            }

            IsPaid = true;
            return true;
        }

        public void PrintOrder()
        {
            Console.WriteLine($"\n=== ORDER #{Id} ===");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Customer: {Customer.Name} (#{Customer.Id})");
            Console.WriteLine($"Paid: {(IsPaid ? "yes" : "no")}");
            Console.WriteLine("Lines:");

            foreach (var line in _lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine($"TOTAL: {CalculateTotal():F2}");
        }
    }
}
