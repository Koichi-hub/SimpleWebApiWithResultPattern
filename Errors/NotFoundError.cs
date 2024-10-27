using FluentResults;

namespace SimpleWebApiWithResultPattern.Errors
{
    public class NotFoundError : Error
    {
        public NotFoundError(string message) : base(message)
        {
            Metadata.Add("ErrorCode", 1);
        }
    }
}
