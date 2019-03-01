using TrafficSignalsConfigurator.Domain;
using TrafficSignalsConfigurator.Domain.DTOs;

namespace TrafficSignalsConfigurator.Domain.Mappers
{
    internal static class UserMapper
    {
        internal static User Map(UserDto userDto)
        {
            return new User(userDto.Id, userDto.Username, userDto.Email, userDto.Password);
        }

        public static UserDto Map(User newUser)
        {
            return new UserDto
            {
                Id = newUser.Id,
                Email = newUser.Email,
                Password = newUser.HashedPassword,
                Username = newUser.Username
            };
        }
    }
}