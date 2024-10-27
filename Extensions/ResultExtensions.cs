using FluentResults;
using SimpleWebApiWithResultPattern.Dtos;

namespace SimpleWebApiWithResultPattern.Extensions
{
    public static class ResultExtensions
    {
        public static ApiResult<T> ToApiResult<T>(this Result<T> result)
        {
            if (result.IsSuccess)
                return ApiResult<T>.Success(result.Value);

            return ApiResult<T>.Fail(result.Errors.Select(TransformError));
        }

        private static ErrorDto TransformError(IError error)
        {
            var errorCode = TransformErrorCode(error);

            return new ErrorDto(errorCode, error.Message);
        }

        private static int TransformErrorCode(IError error)
        {
            if (error.Metadata.TryGetValue("ErrorCode", out var errorCode))
                return (int)errorCode;

            return default;
        }
    }
}
