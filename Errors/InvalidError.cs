using FluentResults;

namespace SimpleWebApiWithResultPattern.Errors
{
    public class InvalidError(string message) : Error(message)
    {
    }
}
