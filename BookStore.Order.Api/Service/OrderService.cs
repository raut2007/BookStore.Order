using BookStore.User.Api.Domain.Model;
using BookStore.User.Api.Repository;

namespace BookStore.User.Api.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        public OrderService(IOrderRepository repo) => _repo = repo;

        public async Task<bool> AddNewOrderAsync(List<OrderRequest> ordersRequest)
        {
            var lastId = _repo.GetLastId().Result;

            List<OrderModel> orders = new List<OrderModel>();
            foreach (var item in ordersRequest)
            {
                lastId++;
                orders.Add(new OrderModel
                {
                    Id = lastId,
                    BookId = item.BookId,
                    UserId = item.UserId,
                    IsActive=   true,
                    IsDeleted= false,
                    CreatedBy = 101,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = 101,
                    UpdatedDate = DateTime.Now,
                });
            }
            return await _repo.AddNewOrderAsync(orders);
        }

        public Task<List<OrderResponse>> GetAllOrdersAsync()
        {
            return _repo.GetAllOrdersAsync();
        }

        public async Task<List<OrderResponse>> GetOrdersByUserIdAsync(int userId)
        {
            return await _repo.GetOrdersByUserIdAsync(userId) ;
        }
    }
}
