using CustomerCart.Domain;

namespace CustomerCart.Application
{
    public class OrderDetailsService : IOrderDetailsService
    {
        public IOrderDetailsRepository OrderDetailsRepository { get; }
        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
        {
            OrderDetailsRepository = orderDetailsRepository;
        }
        public MyCart GetOrderDetails(string userEmail, string customerId)
        {
            var orderDetails = OrderDetailsRepository.GetOrderDetails(userEmail, customerId);
            if(orderDetails != null)
            {
                if(orderDetails.Order != null)
                {

                    if(orderDetails.Order.ContainsGift == true)
                    {
                        orderDetails.Order.OrderItems.ForEach(orderItem => orderItem.Product = "Gift");
                    }
                }
            }
            return orderDetails;
        }

        public bool CheckValidUser(string userEmail, string customerId)
        {
            var customerIdFromDb = OrderDetailsRepository.GetCUstomerIdByEmail(userEmail);
            if(customerIdFromDb != customerId)
                return false;
            return true;
        }
    }
}
