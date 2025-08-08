namespace BookStore.User.Api.Domain.Model
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
