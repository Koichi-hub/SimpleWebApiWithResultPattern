using FluentResults;
using SimpleWebApiWithResultPattern.Dtos;
using SimpleWebApiWithResultPattern.Errors;
using SimpleWebApiWithResultPattern.Models;

namespace SimpleWebApiWithResultPattern.Services
{
    public class UserService
    {
        private readonly static List<User> users = [
            new()
            {
                Id = 1,
                Name = "Naruto",
            },
            new()
            {
                Id = 2,
                Name = "Sasuke",
            },
            new()
            {
                Id = 3,
                Name = "Sakura",
            },
        ];

        public Result<User> AddUser(User user)
        {
            var result = ValidateUser(user);
            if (result.IsFailed)
                return result;

            users.Add(user);

            return user;
        }

        private static Result ValidateUser(User user)
        {
            var result = new Result();

            if (user.Id <= 0)
                result.WithError(new InvalidError("Id must be more than zero")
                    .WithMetadata("ErrorCode", InvalidUserFieldErrorCodeEnum.InvalidId));

            if (users.Any(x => x.Id == user.Id))
                result.WithError(new InvalidError("Id is busy")
                    .WithMetadata("ErrorCode", InvalidUserFieldErrorCodeEnum.BusyId));

            if (string.IsNullOrWhiteSpace(user.Name))
                result.WithError(new InvalidError("Name must be not empty")
                    .WithMetadata("ErrorCode", InvalidUserFieldErrorCodeEnum.InvalidName));

            return result;
        }

        public Result<User> GetUserById(int userId)
        {
            var user = users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
                return new NotFoundError("User was not found");

            return user;
        }
    }
}
