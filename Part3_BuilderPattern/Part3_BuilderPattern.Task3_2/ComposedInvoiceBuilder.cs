using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern
{
    internal class ComposedInvoiceBuilder
    {
        private int _invoiceId;
        private string _customerName = string.Empty;
        private string _customerEmail = string.Empty;
        private string _customerPhone = string.Empty;

        private Address? _billingAddress;
        private Address? _shippingAddress;
        private OrderDetails? _orderDetails;

        public ComposedInvoiceBuilder WithInvoiceId(int id) { _invoiceId = id; return this; }
        public ComposedInvoiceBuilder WithCustomer(string name, string email = "", string phone = "")
        {
            _customerName = name;
            _customerEmail = email;
            _customerPhone = phone;
            return this;
        }

        
        public ComposedInvoiceBuilder WithBillingAddress(Action<AddressBuilder> configureAddress)
        {
            var builder = new AddressBuilder();
            configureAddress(builder);
            _billingAddress = builder.Build();
            return this;
        }

       
        public ComposedInvoiceBuilder WithShippingAddress(Action<AddressBuilder> configureAddress)
        {
            var builder = new AddressBuilder();
            configureAddress(builder);
            _shippingAddress = builder.Build();
            return this;
        }

        
        public ComposedInvoiceBuilder WithOrderDetails(Action<OrderDetailsBuilder> configureOrder)
        {
            var builder = new OrderDetailsBuilder();
            configureOrder(builder);
            _orderDetails = builder.Build();
            return this;
        }

        public Invoice Build()
        {
            if (_invoiceId <= 0)
                throw new InvalidOperationException("InvoiceId must be greater than zero.");

            if (string.IsNullOrWhiteSpace(_customerName))
                throw new InvalidOperationException("Customer name is required.");

            if (_billingAddress == null)
                throw new InvalidOperationException("Billing address is required.");

            if (_shippingAddress == null)
                throw new InvalidOperationException("Shipping address is required.");

            if (_orderDetails == null)
                throw new InvalidOperationException("Order details are required.");

            return new Invoice(_invoiceId, _customerName, _customerEmail, _customerPhone, _billingAddress, _shippingAddress, _orderDetails);
        }
    }
}

