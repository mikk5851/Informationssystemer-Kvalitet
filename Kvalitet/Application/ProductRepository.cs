using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application
{
    public class ProductRepository : Product
    {
        private List<Product> products = new List<Product>();

        /*/ public Product GetProduct(int ID)
         {

         }
         /*/

        public void AddProduct(Product product, int ID, string name, string description, double price, int mininstock)
        {

        }

        public void Clear()
        {

        }
        
    }
}
