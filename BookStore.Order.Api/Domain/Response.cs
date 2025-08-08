namespace BookStore.User.Api.Domain
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Error { get; set; }
        public Response(bool isSuccess, T? data, string? error ) 
        {
            IsSuccess = isSuccess;
            Data = data;
            Error = error;
        }
    }
}
