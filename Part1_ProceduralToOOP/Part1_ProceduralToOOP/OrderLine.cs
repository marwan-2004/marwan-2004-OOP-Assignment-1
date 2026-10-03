using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_ProceduralToOOP
{
    public class OrderLine
    {
        public Product product { get;  }
        public int Quantity { get; }
        public decimal TotalPrice => product.Price * Quantity;

        public OrderLine(Product product, int quantity)
        {
            this.product = product;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            return $" - {product.Name} x {Quantity}  @{product.Price:F2}  ={TotalPrice}";
        }
    }
}
