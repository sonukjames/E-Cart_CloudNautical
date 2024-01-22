using CustomerCart.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCart.Application
{
    public interface IOrderDetailsRepository
    {
        MyCart GetOrderDetails(string userEmail, string customerId);
        string GetCUstomerIdByEmail(string email);
    }
}
