using CodingChallengeInnostepIt.Persistence.Entities;

namespace CodingChallengeInnostepIt.WebApi.Persistence.Repositories;
public interface IUserRepository
{
    public Task<IEnumerable<UserEntity>> GetAllUsers();
    public Task<UserEntity> GetById(string id);
    public Task Create(UserEntity user);
    public Task<UserEntity> Update(string id, UserEntity updateUser);
    public Task<bool> DeleteById(string id);
}
