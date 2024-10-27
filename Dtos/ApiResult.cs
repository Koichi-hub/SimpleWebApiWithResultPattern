namespace SimpleWebApiWithResultPattern.Dtos
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; }

        public T? Data { get; set; }

        public IEnumerable<ErrorDto>? Errors { get; set; }

        public static ApiResult<T> Fail(IEnumerable<ErrorDto> errors)
        {
            return new ApiResult<T> { 
                IsSuccess = false, 
                Errors = errors
            };
        }

        public static ApiResult<T> Success(T data)
        {
            return new ApiResult<T>
            {
                IsSuccess = true,
                Data = data
            };
        }
    }

    public class ErrorDto(int code, string message)
    {
        public int Code { get; set; } = code;

        public string Message { get; set; } = message;
    }
}
