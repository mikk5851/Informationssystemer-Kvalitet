using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class OrderRepository
    {
        
        
        public static readonly OrderRepository GetOrderRepository;
        private List<Order> orders = new List<Order>();

        static OrderRepository()
        {
            GetOrderRepository = new OrderRepository();
        }

        private OrderRepository() { }

        public Order GetOrder(int ID)
        {
            throw new NotImplementedException();
        }
            

        public void AddOrder(Order order, Customer customer, int ID, DateTime orderdate, DateTime deliverydate, bool picked)
        {

        }

        public void Clear()
        {

        }

        public IEnumerator<Order> GetEnumerator()
        {
            return orders.GetEnumerator();
        }
        
    }
}
