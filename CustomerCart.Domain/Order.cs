using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCart.Domain
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime DeliveryExpected { get; set; }
        public bool ContainsGift { get; set; }
    }
}
