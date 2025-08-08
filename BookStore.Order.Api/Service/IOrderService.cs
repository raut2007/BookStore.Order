using BookStore.User.Api.Domain.Model;

namespace BookStore.User.Api.Service
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetAllOrdersAsync();
        Task<List<OrderResponse>> GetOrdersByUserIdAsync(int userId);
        Task<bool> AddNewOrderAsync(List<OrderRequest> ordersRequest);
    }
}
