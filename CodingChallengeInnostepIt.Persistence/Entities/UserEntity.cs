using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CodingChallengeInnostepIt.Persistence.Entities;
public class UserEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string ForName { get; set; }
    public string SureName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}
