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
        public class ProductRepository : Order
        {
            private List<Order> orders = new List<Order>();

            /*/ public Order GetOrder(int ID)
             {

             }
             /*/

            public void AddOrder(Order order, Customer customer, int ID, DateTime orderdate, DateTime deliverydate, bool picked)
            {

            }

            public void Clear()
            {

            }
        }
    }
}
