using System;

namespace Part1_ProceduralToOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Procedural Order System Refactored to OOP in C#");
            Console.WriteLine("Seed sample data, show a demo, then open the menu.");

            var manager = new OrderSystemManager();
            manager.SeedSampleData();
            manager.RunDemoScenario();

            manager.PrintCustomers();
            manager.PrintProducts();
            manager.PrintAllOrders();

            Console.WriteLine($"\nPaid sales total after demo: {manager.TotalSalesPaidOnly():F2}");

            RunInteractiveMenu(manager);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n---------- MENU ----------");
            Console.WriteLine("1) Print customers");
            Console.WriteLine("2) Print products");
            Console.WriteLine("3) Print all orders");
            Console.WriteLine("4) Print one order by id");
            Console.WriteLine("5) Create order");
            Console.WriteLine("6) Add line to order");
            Console.WriteLine("7) Mark order paid");
            Console.WriteLine("8) Show paid sales total");
            Console.WriteLine("0) Exit");
            Console.Write("Choice: ");
        }

        private static void RunInteractiveMenu(OrderSystemManager manager)
        {
            int choice = -1;
            while (choice != 0)
            {
                PrintMenu();
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        manager.PrintCustomers();
                        break;
                    case 2:
                        manager.PrintProducts();
                        break;
                    case 3:
                        manager.PrintAllOrders();
                        break;
                    case 4:
                        Console.Write("Order id: ");
                        if (int.TryParse(Console.ReadLine(), out int oId))
                            manager.PrintOrder(oId);
                        break;
                    case 5:
                        Console.Write("Order id: ");
                        int orderId = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Customer id: ");
                        int customerId = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Date (YYYY-MM-DD): ");
                        string date = Console.ReadLine() ?? "";
                        manager.CreateOrder(orderId, customerId, date);
                        break;
                    case 6:
                        Console.Write("Order id: ");
                        int lineOrderId = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Product id: ");
                        int productId = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Quantity: ");
                        int quantity = int.Parse(Console.ReadLine() ?? "0");
                        manager.AddLineToOrder(lineOrderId, productId, quantity);
                        break;
                    case 7:
                        Console.Write("Order id: ");
                        if (int.TryParse(Console.ReadLine(), out int payOrderId))
                            manager.MarkOrderPaid(payOrderId);
                        break;
                    case 8:
                        Console.WriteLine($"Paid sales total: {manager.TotalSalesPaidOnly():F2}");
                        break;
                    case 0:
                        Console.WriteLine("Bye.");
                        break;
                    default:
                        Console.WriteLine("Unknown choice.");
                        break;
                }
            }
        }
    }
}