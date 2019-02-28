using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SaleOrderLine
    {
        public Status status;
        public Product Product;
        public int Quantity;
        public double Price;
        private int index;

        public SaleOrderLine(int index)
        {
            this.index = index;
        }

        public SaleOrderLine(Product product, int quantity, double price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }
    }
}
