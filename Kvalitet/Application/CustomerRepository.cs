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

        public Customer GetCustomer(int iD)
        {
            foreach (Customer customer in customers)
            {
                if (iD == customer.ID)
                {
                    return customer;
                }
            }

            throw new ArgumentException($"Customer with id {iD} not found");
        }

        public void AddCustomer(Customer customer)
        {
            Customer cus = new Customer(customer);
            customers.Add(cus);
        }

        public void AddCustomer(int iD, string name, string address, int ZIP, string town, int telephone)
        {
            Customer cus = new Customer(iD, name, address, ZIP, town, telephone);
            customers.Add(cus);
        }

        public void Clear()
        {
            customers.Clear();
        }
    }
}

