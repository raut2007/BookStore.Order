using BookStore.User.Api.Domain.Model;
using BookStore.User.Api.Service;
using MediatR;

namespace BookStore.User.Api.Logic.Query
{
    public record GetOrdersByUserIdQuesy: IRequest<List<OrderResponse>>
    {
        public int _userId { get; set; }
        public GetOrdersByUserIdQuesy(int userId)
        {
            _userId = userId;
        }
    }

    public class GetOrdersByUserIdHandler : IRequestHandler<GetOrdersByUserIdQuesy, List<OrderResponse>>
    {
        private readonly IOrderService _service;
        public GetOrdersByUserIdHandler(IOrderService service) => _service = service;

        public async Task<List<OrderResponse>> Handle(GetOrdersByUserIdQuesy request, CancellationToken cancellationToken)
        {
            var orders = await _service.GetOrdersByUserIdAsync(request._userId);
            return orders;
        }
    }
}
