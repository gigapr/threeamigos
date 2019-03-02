using System;
using System.Threading.Tasks;
using TrafficSignalsConfigurator.Domain;
using TrafficSignalsConfigurator.Domain.DTOs;

namespace TrafficSignalsConfigurator.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsEmailUnique(string email) ;
        Task<bool>  IsUsernameUnique (string username);
        Task<UserDto> GetByEmail(string email);
        void Update(string id, User newUser);
        void Remove(string id);
        Task Add(string userId, string username, string email, string password);
    }
}
