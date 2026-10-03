using System;
using Part3_BuilderPattern;

namespace Part3_BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Composed Builder Pattern Demo ===");

            var invoice = new ComposedInvoiceBuilder()
                .WithInvoiceId(1001)
                .WithCustomer("Mona Ali", "mona@example.com", "01000000000")
                .WithBillingAddress(addr => addr
                    .WithStreet("123 Nile St")
                    .WithCity("Cairo")
                    .WithState("Cairo")
                    .WithZipCode("11511")
                    .WithCountry("Egypt"))
                .WithShippingAddress(addr => addr
                    .WithStreet("456 Cornish St")
                    .WithCity("Alexandria")
                    .WithState("Alexandria")
                    .WithZipCode("21500")
                    .WithCountry("Egypt"))
                .WithOrderDetails(order => order
                    .WithDate(DateTime.Now)
                    .WithPaymentMethod("Credit Card")
                    .WithCurrency("EGP")
                    .WithSubTotal(1500.00m)
                    .WithDiscount(100.00m)
                    .WithTax(200.00m))
                .Build();

            Console.WriteLine($"Invoice #{invoice.InvoiceId} created for {invoice.CustomerName}");
            Console.WriteLine($"Billing City: {invoice.BillingAddress.City}");
            Console.WriteLine($"Shipping City: {invoice.ShippingAddress.City}");
            Console.WriteLine($"Total Amount: {invoice.Details.TotalAmount} {invoice.Details.Currency}");
        }
    }
}