using BookStore.User.Api.Domain.Model;

namespace BookStore.User.Api.Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderResponse>> GetAllOrdersAsync();
        Task<List<OrderResponse>> GetOrdersByUserIdAsync(int userId);
        Task<bool> AddNewOrderAsync(List<OrderModel> orders);
        Task<int> GetLastId();
    }
}
