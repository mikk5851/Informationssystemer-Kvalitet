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

        public Order GetOrder(int iD)
        {
            foreach (Order order in orders)
            {
                if (iD == order.ID)
                {
                    return order;
                }


            }

            throw new ArgumentException($"order with id {iD} not found");
        }


        public void AddOrder(Order order)

        {
            Order ord = new Order(order);
            orders.Add(ord);
        }

        public void AddOrder(Customer cus, int iD, DateTime orderdate, DateTime deliverydate, bool picked)
        {
            Order ord = new Order(cus, iD, orderdate, deliverydate, picked);
            orders.Add(ord);

        }

        public void Clear()
        {
            orders.Clear();
        }



    }
}
