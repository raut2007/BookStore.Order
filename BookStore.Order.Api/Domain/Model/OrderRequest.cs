namespace BookStore.User.Api.Domain.Model
{
    public class OrderRequest
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
