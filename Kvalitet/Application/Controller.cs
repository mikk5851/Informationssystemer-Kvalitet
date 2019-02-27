using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Controller
    {
        public static readonly Controller GetController;

        static Controller()
        {
            GetController = new Controller();
        }

        private Controller() { }

        public void RecieveOrder()
        {

        }
    }
}
