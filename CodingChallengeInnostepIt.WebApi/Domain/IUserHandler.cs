using CodingChallengeInnostepIt.Persistence.DTOs;

namespace CodingChallengeInnostepIt.WebApi.Domain;
public interface IUserHandler
{
    public Task<IEnumerable<ReadUserDTO>> GetAllUsers();
    public Task<ReadUserDTO> GetUserById(string userId);
    public Task CreateUser(CreateUserDto newUser);
    public Task<ReadUserDTO> UpdateUser(string id, UpdateUserDto user);
    public Task<bool> DeleteUser(string userId);
}
