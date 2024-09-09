using CodingChallengeInnostepIt.Persistence.DTOs;
using CodingChallengeInnostepIt.Persistence.Entities;

namespace CodingChallengeInnostepIt.WebApi.Mapper
{
    public interface IUserMapper
    {
        public ReadUserDTO MapUserEntityToReadUserDto(UserEntity userEntity);

        public UserEntity MapCreateUserDtoToUserEntity(CreateUserDto userDto);
        public UserEntity MapUpdateUserDtoToUserEntity(UpdateUserDto userDto);
    }
}
