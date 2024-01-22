using CustomerCart.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCart.Application
{
    public interface IOrderDetailsService
    {
        MyCart GetOrderDetails(string userEmail, string customerId);
        bool CheckValidUser(string userEmail, string customerId);
    }
}
