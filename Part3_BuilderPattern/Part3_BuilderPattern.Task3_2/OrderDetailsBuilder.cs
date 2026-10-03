using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern
{
    public class OrderDetailsBuilder
    {
        private DateTime _orderDate = DateTime.Now;
        private string _paymentMethod = "Credit Card";
        private string _currency = "USD";
        private decimal _subTotal;
        private decimal _discountAmount;
        private decimal _taxAmount;

        public OrderDetailsBuilder WithDate(DateTime date) { _orderDate = date; return this; }
        public OrderDetailsBuilder WithPaymentMethod(string method) { _paymentMethod = method; return this; }
        public OrderDetailsBuilder WithCurrency(string currency) { _currency = currency; return this; }
        public OrderDetailsBuilder WithSubTotal(decimal subTotal) { _subTotal = subTotal; return this; }
        public OrderDetailsBuilder WithDiscount(decimal discount) { _discountAmount = discount; return this; }
        public OrderDetailsBuilder WithTax(decimal tax) { _taxAmount = tax; return this; }

        public OrderDetails Build()
        {
            if (_subTotal <= 0)
                throw new InvalidOperationException("Order validation failed: 'SubTotal' must be greater than zero.");

            return new OrderDetails(_orderDate, _paymentMethod, _currency, _subTotal, _discountAmount, _taxAmount);
        }
    }
}
