using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum Status : byte
    {
        Nothing,
        Alter,
        Create,
        Delete
    }
    public class Customer
    {
        public int CustomerID;
        public string Name;
        public string Address;
        public int ZIP;
        public string Town;
        public int Telephone;
        public Status status;
        private Customer customer;
        public int ID;

        public Customer(Customer customer)
        {
            this.customer = customer;
            status = Status.Create;
        }

        public Customer(int iD, string name, string address, int zIP, string town, int telephone)
        {
            this.ID = iD;
            Name = name;
            Address = address;
            ZIP = zIP;
            Town = town;
            Telephone = telephone;
            status = Status.Create;
        }
    }
}
