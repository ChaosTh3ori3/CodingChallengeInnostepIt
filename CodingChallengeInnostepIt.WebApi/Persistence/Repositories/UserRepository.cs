using CodingChallengeInnostepIt.Persistence.Entities;
using CodingChallengeInnostepIt.WebApi.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CodingChallengeInnostepIt.WebApi.Persistence.Repositories;
public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    public UserRepository(IOptions<MongoDbSettings> dbSettings) 
        : base(dbSettings, dbSettings.Value.UserCollectionName)
    {
    }

    public async Task Create(UserEntity user)
    {
        await Collection.InsertOneAsync(user);
    }

    public async Task<bool> DeleteById(string id)
    {
        var result = await Collection.DeleteOneAsync(user => user.Id == id);

        return result.DeletedCount > 0;
    }

    public async Task<IEnumerable<UserEntity>> GetAllUsers()
    {
        return await Collection.AsQueryable().ToListAsync();
    }

    public async Task<UserEntity> GetById(string id)
    {
        return await Collection.AsQueryable().FirstAsync(user => user.Id == id);
    }

    public async Task<UserEntity> Update(string id, UserEntity updateUser)
    {
        var filter = Builders<UserEntity>.Filter
            .Eq(user => user.Id, id);

        var update = Builders<UserEntity>.Update
            .Set(user => user.Email, updateUser.Email)
            .Set(user => user.ForName, updateUser.ForName)
            .Set(user => user.SureName, updateUser.SureName)
            .Set(user => user.BirthDate, updateUser.BirthDate);

        return await Collection.FindOneAndUpdateAsync(filter, update);
    }
}
