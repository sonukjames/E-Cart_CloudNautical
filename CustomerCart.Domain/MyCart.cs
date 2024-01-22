using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCart.Domain
{
    public class MyCart
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Order Order { get; set; }
    }
}
