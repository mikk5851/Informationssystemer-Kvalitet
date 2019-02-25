using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CustomerRepository : Customer
    {
        private List<Customer> customers = new List<Customer>();

        /*/ public Customer GetCustomer(int ID)
         {

         }
         /*/

        public void AddCustomer(Customer customer, int ID, string name, string address, int ZIP, string town, int telephone)
        {

        }

        public void Clear()
        {

        }
    }
}
