using System;
using System.Threading.Tasks;

namespace TrafficSignalsConfigurator.EventsHandlers.Domain.Repositories
{
    public interface IUserRepository
    {
        // void Update(string id, User newUser);
        // void Remove(string id);
        Task Add(string userId, string username, string email, string password);
    }
}
