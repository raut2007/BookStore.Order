using BookStore.User.Api.Domain.Model;

namespace BookStore.User.Api.Repository
{
    public class OrderRepository: IOrderRepository
    {
        public async Task<bool> AddNewOrderAsync(List<OrderModel> orders)
        {
            OrderList.Orders.AddRange(orders);

            return true;
        }

        public async Task<List<OrderResponse>> GetAllOrdersAsync()
        {
            var orders = OrderList.Orders
             .Where(u => u.IsActive && !u.IsDeleted)
             .Select(u => new OrderResponse
             {
                 Id = u.Id,
                 UserId = u.UserId,
                 BookId = u.BookId,
             })
             .ToList();

            return orders;
        }

        public async Task<int> GetLastId()
        {
            int lastId = OrderList.Orders.Any()
            ? OrderList.Orders.Max(o => o.Id)
            : 0;

            return lastId;
        }

        public async Task<List<OrderResponse>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = OrderList.Orders
             .Where(u => u.IsActive && !u.IsDeleted && u.UserId == userId)
             .Select(u => new OrderResponse
             {
                 Id = u.Id,
                 UserId = u.UserId,
                 BookId = u.BookId,
             })
             .ToList();

            return orders;
        }
    }
}
