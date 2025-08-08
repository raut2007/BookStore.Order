using BookStore.Order.Api.Logic.Command;
using BookStore.User.Api.Domain;
using BookStore.User.Api.Domain.Model;
using BookStore.User.Api.Logic.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Order.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
       
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "getAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(new Response<List<OrderResponse>>(result != null, result, result.Count == 0 ? "No data found" : ""));
        }

        [HttpGet("user/{userId}", Name = "GetOrdersByUserId")]
        public async Task<IActionResult> GetOrdersByUserId(int userId)
        {
            var result = await _mediator.Send(new GetOrdersByUserIdQuesy(userId));
            return Ok(new Response<List<OrderResponse>>(result != null, result, result.Count == 0 ? "No data found" : ""));
        }

        [HttpPost(Name = "addNewOrderAsync")]
        public async Task<IActionResult> AddNewOrderAsync([FromBody]List<OrderRequest> ordersRequest)
        {
            var result = await _mediator.Send(new AddNewOrderCommand(ordersRequest));
            return Ok(new Response<bool>(result, result, result == false ? "No data found" : ""));
        }
    }

}
