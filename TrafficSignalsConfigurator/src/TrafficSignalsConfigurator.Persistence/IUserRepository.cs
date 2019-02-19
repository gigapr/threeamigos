using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TrafficSignalsConfigurator.Persistence
{
    public interface IUserRepository
    {
        Task<bool> IsEmailUnique(string email) ;
        Task<bool>  IsUsernameUniqueAsync (string username);
        User Get(Expression<Func<User, bool>> predicate);
        User Add(User user);
        void Update(string id, User user);
        void Remove(string id);
    }
}
