using Domain.Services.Admin.Dto;
using Domain.Services.Admin.Interface;

namespace Domain.Services.Admin.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserResponseDto>>
            GetAllUsersAsync()
        {
            try
            {
                return await _userRepository
                    .GetAllUsersAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error while getting all users : {ex.Message}");
            }
        }

        public async Task<UserResponseDto?>
            GetUserByIdAsync(Guid id)
        {
            try
            {
                return await _userRepository
                    .GetUserByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error while getting user by id : {ex.Message}");
            }
        }
    }
}