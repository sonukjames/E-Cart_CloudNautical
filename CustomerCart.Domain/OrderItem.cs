using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCart.Domain
{
    public class OrderItem
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int PriceEach { get; set; }
    }
}
