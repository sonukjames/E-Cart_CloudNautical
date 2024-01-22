using CustomerCart.Application;
using CustomerCart.Domain;
using Dapper;
using System.Data;

namespace CustomerCart.Infrastructure
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly DapperDbContext _dbContext;
        public OrderDetailsRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyCart GetOrderDetails(string userEmail, string customerId)
        {
            string query = @"
                            SELECT TOP 1
                                c.FirstName,
                                c.LastName,
                                o.OrderID AS OrderNumber,
                                o.OrderDate,
                                CONCAT(c.HouseNo, ' ', c.Street, ', ', c.Town, ', ', c.PostCode) AS DeliveryAddress,
                                oi.Quantity,
                                oi.Price AS PriceEach,
                                p.ProductName AS Product,
                                o.DeliveryExpected,
                                o.ContainsGift
                            FROM
                                Customers c
                            INNER JOIN
                                Orders o ON c.CustomerID = o.CustomerID
                            INNER JOIN
                                OrderItems oi ON o.OrderID = oi.OrderID
                            INNER JOIN
                                Products p ON oi.ProductID = p.ProductID
                            WHERE
                                c.CustomerID = @customerId AND
                                c.Email = @userEmail
                            ORDER BY
                                o.OrderDate DESC;";

            try
            {
                using (var dbConnection = _dbContext.CreateConnection())
                {
                    var parameters = new { customerId, userEmail };
                    var result = dbConnection.Query<MyCart, OrderItem, Product, MyCart>(
                        query,
                        (myCart, orderItem, product) =>
                        {
                            myCart.Order = myCart.Order ?? new Order();
                            myCart.Order.OrderItems = myCart.Order.OrderItems ?? new List<OrderItem>();
                            orderItem.Product = product.ProductName;
                            myCart.Order.OrderItems.Add(orderItem);
                            return myCart;
                        },
                        parameters,
                        splitOn: "OrderNumber, Quantity"
                    ).FirstOrDefault();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string GetCUstomerIdByEmail(string email)
        {
            var query = "SELECT CustomerId from Customer WHERE Email = @email;";
            var parameter = new { email };
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    var result = connection.QueryFirstOrDefault(query, parameter);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
