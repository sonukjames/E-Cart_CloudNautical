using CustomerCart.Api.Models;
using CustomerCart.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CustomerCart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        public IOrderDetailsService _orderDetailsService { get; set; }
        public OrderDetailsController(IOrderDetailsService orderDetailsService) 
        {
            _orderDetailsService = orderDetailsService;
        }
        // GET: api/<ValuesController>
        [HttpPost]
        public IActionResult GetOrderDetails(CustomerDetails customerDetails)
        {
            if (!Validate(customerDetails))
                return BadRequest();
                return Ok(_orderDetailsService.GetOrderDetails(customerDetails.User, customerDetails.CustomerId));
        }


        private bool Validate(CustomerDetails customerDetails)
        {
            if(customerDetails.CustomerId.IsNullOrEmpty() || customerDetails.User.IsNullOrEmpty())
                return false;
            return _orderDetailsService.CheckValidUser(customerDetails.User, customerDetails.CustomerId);
        }
    }
}
