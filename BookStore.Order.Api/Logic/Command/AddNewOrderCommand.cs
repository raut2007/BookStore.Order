using BookStore.User.Api.Domain.Model;
using BookStore.User.Api.Service;
using MediatR;

namespace BookStore.Order.Api.Logic.Command
{
    public record AddNewOrderCommand : IRequest<bool>
    {
        public List<OrderRequest> _orders { get; set; }
         
        public AddNewOrderCommand(List<OrderRequest> orders)
        {
            _orders = orders;
        }
    }

    public class RegisterUserHandler : IRequestHandler<AddNewOrderCommand, bool>
    {
        private readonly IOrderService _service;
        public RegisterUserHandler(IOrderService service) => _service = service;

        public async Task<bool> Handle(AddNewOrderCommand request, CancellationToken cancellationToken)
        {
            var isValid = Validation(request).Result;
            if (isValid)
            {
                var result = await _service.AddNewOrderAsync(request._orders);
                return result;
            }
            return false;
        }

        private async Task<bool> Validation(AddNewOrderCommand request)
        {
            var result = true;
            if (request._orders == null) result = false;
            return result;
        }
    }
}
