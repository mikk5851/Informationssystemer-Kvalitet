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

        public Product GetProduct(int ID)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product, int ID, string name, string description, double price, int mininstock)
        {

        }

        public void Clear()
        {

        }
        
    }
}
