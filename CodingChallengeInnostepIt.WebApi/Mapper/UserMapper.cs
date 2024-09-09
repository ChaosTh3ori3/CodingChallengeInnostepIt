using CodingChallengeInnostepIt.Persistence.DTOs;
using CodingChallengeInnostepIt.Persistence.Entities;

namespace CodingChallengeInnostepIt.WebApi.Mapper;
public class UserMapper : IUserMapper
{
    public UserEntity MapCreateUserDtoToUserEntity(CreateUserDto userDto)
    {
        return new UserEntity()
        {
            ForName = userDto.ForName,
            SureName = userDto.SureName,
            Email = userDto.Email,
            BirthDate = userDto.BirthDate
        };
    }

    public UserEntity MapUpdateUserDtoToUserEntity(UpdateUserDto userDto)
    {
        return new UserEntity()
        {
            Id = userDto.Id,
            BirthDate = userDto.BirthDate,
            Email = userDto.Email,
            ForName = userDto.ForName,
            SureName = userDto.SureName
        };
    }

    public ReadUserDTO MapUserEntityToReadUserDto(UserEntity userEntity)
    {
        return new ReadUserDTO()
        {
            Id = userEntity.Id,
            BirthDate = userEntity.BirthDate,
            Email = userEntity.Email,
            ForName = userEntity.ForName,
            SureName = userEntity.SureName
        };
    }
}
