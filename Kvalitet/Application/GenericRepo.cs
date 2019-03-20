using System;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GenericRepo<T> where T : IHaveID
    {
        public static readonly GenericRepo<Customer> GetCustomerRepository;
        public static readonly GenericRepo<Order> GetOrderrRepository;
        public static readonly GenericRepo<Product> GetProductRepository;

        private List<T> ItemList = new List<T>();

        static GenericRepo()
        {
            GetCustomerRepository = new GenericRepo<Customer>();
            GetOrderrRepository = new GenericRepo<Order>();
            GetOrderlineRepository = new GenericRepo<SaleOrderline>();
        }
        private GenericRepo() { }

        public T GetItem(int id)
        {
            foreach (T item in ItemList)
            {
                if(item.ID == id) { return item; }
            }
            throw new ArgumentException($"{T.GetType} with {id} not found");
        }

        public void AddItem(T item)
        {
            ItemList.Add(item);
        }

        public static void AddCustomer(int iD, string name, string address, int ZIP, string town, int telephone)
        {
            Customer cus = new Customer(iD, name, address, ZIP, town, telephone);
            GetCustomerRepository.Add(cus);
        }

        public void Clear()
        {
            ItemList.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ItemList.GetEnumerator;
        }
    }
}
