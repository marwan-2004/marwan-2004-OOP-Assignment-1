using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern
{
    public class Invoice
    {
        public int InvoiceId { get; }
        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public string CustomerPhone { get; }
        public Address BillingAddress { get; }
        public Address ShippingAddress { get; }
        public OrderDetails Details { get; }

        public Invoice(int id, string name, string email, string phone, Address billing, Address shipping, OrderDetails details)
        {
            InvoiceId = id;
            CustomerName = name;
            CustomerEmail = email;
            CustomerPhone = phone;
            BillingAddress = billing;
            ShippingAddress = shipping;
            Details = details;
        }
    }
}
