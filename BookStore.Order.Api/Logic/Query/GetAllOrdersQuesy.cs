using BookStore.User.Api.Domain.Model;
using BookStore.User.Api.Service;
using MediatR;

namespace BookStore.User.Api.Logic.Query
{
    public record GetAllOrdersQuery() : IRequest<List<OrderResponse>>;

    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderResponse>>
    {
        private readonly IOrderService _service;
        public GetAllOrdersHandler(IOrderService service) => _service = service;

        public Task<List<OrderResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = _service.GetAllOrdersAsync();
            return orders;
        }
    }
}
