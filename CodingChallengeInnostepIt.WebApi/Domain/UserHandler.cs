using CodingChallengeInnostepIt.Persistence.DTOs;
using CodingChallengeInnostepIt.WebApi.Mapper;
using CodingChallengeInnostepIt.WebApi.Persistence.Repositories;

namespace CodingChallengeInnostepIt.WebApi.Domain
{
    public class UserHandler : IUserHandler
    {
        private readonly IUserRepository userRepository;
        private readonly IUserMapper userMapper;

        public UserHandler(IUserRepository userRepository, IUserMapper userMapper)
        {
            this.userRepository = userRepository;
            this.userMapper = userMapper;
        }

        public async Task CreateUser(CreateUserDto newUser)
        {
            var userEntity = userMapper.MapCreateUserDtoToUserEntity(newUser);

            await userRepository.Create(userEntity);
        }

        public async Task<bool> DeleteUser(string userId)
        {
            return await userRepository.DeleteById(userId);
        }

        public async Task<IEnumerable<ReadUserDTO>> GetAllUsers()
        {
            var users = await userRepository.GetAllUsers();

            var userDtos = users.Select(userMapper.MapUserEntityToReadUserDto);

            return userDtos;
        }

        public async Task<ReadUserDTO> GetUserById(string userId)
        {
            var userEntity = await userRepository.GetById(userId);
            return userMapper.MapUserEntityToReadUserDto(userEntity);
        }

        public async Task<ReadUserDTO> UpdateUser(string id, UpdateUserDto user)
        {
            var userEntity = userMapper.MapUpdateUserDtoToUserEntity(user);

            var updatedUserEntity = await userRepository.Update(id, userEntity);

            return userMapper.MapUserEntityToReadUserDto(updatedUserEntity);
        }
    }
}
