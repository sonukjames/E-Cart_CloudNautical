using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCart.Domain
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }
    }

}
