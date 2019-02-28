using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int ProductID;
        public string Name;
        public string Description;
        public double Price;
        public int MinInStock;
        public Status status;
        public int ID;
        public Product product;
        private int quantity;

        public Product(Product product)
        {
            this.product = product;
            status = Status.Create;
        }

        public Product(Product product, int quantity, double price) : this(product)
        {
            this.quantity = quantity;
            Price = price;
        }

        public Product(int iD, string name, string description, double price, int mininstock)
        {
            this.ID = iD;
            Name = name;
            Description = description;
            Price = price;
            MinInStock = mininstock;
            status = Status.Create;
        }


    }
}


