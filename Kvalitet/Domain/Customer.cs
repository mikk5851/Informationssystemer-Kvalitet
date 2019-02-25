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

    }
}
