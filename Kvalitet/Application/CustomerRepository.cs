using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CustomerRepository
    {
        public static readonly CustomerRepository GetCustomerRepository;
        private List<Customer> customers = new List<Customer>();

        static CustomerRepository()
        {
            GetCustomerRepository = new CustomerRepository();
        }

        private CustomerRepository() { }

        public Customer GetCustomer(int ID)
        {
           throw new NotImplementedException();
        }

        public void AddCustomer(Customer customer, int ID, string name, string address, int ZIP, string town, int telephone)
        {

        }

        public void Clear()
        {

        }

        public IEnumerator<Customer> GetEnumerator()
        {
            return customers.GetEnumerator();
        }
    }
}
