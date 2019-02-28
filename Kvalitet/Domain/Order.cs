using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class Order
    {

        private List<SaleOrderLine> OrderLines = new List<SaleOrderLine>();

        public Customer Customer;
        public int OrderID;
        public DateTime OrderDate;
        public DateTime DeliveryDate;
        public bool Picked;
        public Order order;
        private Customer cus;
        public int ID;
        public Status status;


        public Order(Order order)
        {
            this.order = order;
            status = Status.Create;
        }

        public Order(Customer cus, int iD, DateTime orderdate, DateTime deliverydate, bool picked)
        {
            this.cus = cus;
            this.ID = iD;
            OrderDate = orderdate;
            DeliveryDate = deliverydate;
            Picked = picked;
            status = Status.Create;

        }





        public void AddOrderLine(Product product, int quantity, double price)
        {
            SaleOrderLine orderLine = new SaleOrderLine(product, quantity, price);
            OrderLines.Add(orderLine);

        }

        public void RemoveOrderLine(int index)
        {


        }


        public IEnumerator<SaleOrderLine> GetEnumerator()
        {
            return OrderLines.GetEnumerator();
        }


    }
}
