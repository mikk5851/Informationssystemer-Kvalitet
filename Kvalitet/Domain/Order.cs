using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class Order
    {
        private List<SalesOrderLine> OrderLines = new List<SalesOrderLine>();

        public Customer Customer;
        public int OrderID;
        public DateTime OrderDate;
        public DateTime DeliveryDate;
        public bool Picked;

        public Order(int id)
        {
            OrderID = id;
        }
        public void AddOrderLine(Product product, int quantity, double price)
        {

        }

        public void RemoveOrderLine(int index)
        {

        }

     /*/   public SalesOrderLine GetOrderLine()
        {
            
        } /*/
    }
}
