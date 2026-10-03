using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern
{
    public class OrderDetails
    {
        public DateTime OrderDate { get; }
        public string PaymentMethod { get; }
        public string Currency { get; }
        public decimal SubTotal { get; }
        public decimal DiscountAmount { get; }
        public decimal TaxAmount { get; }
        public decimal TotalAmount => SubTotal - DiscountAmount + TaxAmount;

        public OrderDetails(DateTime date, string paymentMethod, string currency, decimal subTotal, decimal discount, decimal tax)
        {
            OrderDate = date;
            PaymentMethod = paymentMethod;
            Currency = currency;
            SubTotal = subTotal;
            DiscountAmount = discount;
            TaxAmount = tax;
        }
    }
}
