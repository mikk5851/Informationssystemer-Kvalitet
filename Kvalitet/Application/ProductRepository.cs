using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application
{
    public class ProductRepository
    {
        public static readonly ProductRepository GetProductRepository;
        private List<Product> products = new List<Product>();

        static ProductRepository()
        {
            GetProductRepository = new ProductRepository();
        }
        private ProductRepository() { }

        public Product GetProduct(int iD)
        {
            foreach (Product product in products)
            {
                if (iD == product.ID)
                {
                    return product;
                }
            }

            throw new ArgumentException($"Product with id {iD} not found");
        }



        public void AddProduct(Product product)
        {
            Product prod = new Product(product);
            products.Add(prod);
        }


        public void AddProduct(int iD, string name, string description, double price, int mininstock)
        {
            Product prod = new Product(iD, name, description, price, mininstock);
            products.Add(prod);

        }

        public void Clear()
        {

            {
                products.Clear();
            }
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return products.GetEnumerator();
        }
    }
}
