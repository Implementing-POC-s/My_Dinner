using Dinner.Domain.Entities;

namespace Dinner.Application.Common.Interfaces.Persistence;
public interface IUserRepository
{
    User? GetUserByEmail(string email);//here we might get the user or not if doesn't exist
    void Add(User user);

}