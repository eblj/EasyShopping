namespace EasyShopping.Cart.Application.Abstractions
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public bool IsFound { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public Result(bool isSuccess, string message, bool isFound = true, T data = default)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
            this.IsFound = isFound;
            this.Data = data;
        }

        public static Result<T> Success(T data, string message = "The operation was carried out successfully.")
        {
            return new Result<T>(true, message, data: data);
        }

        public static Result<T> Failure(string message = "The operation failed.", bool isFound = false)
        {
            return new Result<T>(false, message, isFound);
        }

        public static Result<T> NotFound(string message = "Item not found")
        {
            return new Result<T>(false, message, false);
        }
    }
}
