using LibraryProject.Domain.Dto;
using LibraryProject.Domain.Models;

namespace LibraryProject.Application.Interfaces
{
    public interface IUserService
    {
        UserDto Register(RegistrationUserDto user, string role);
        UserDto UpdateUser(string email, UpdateUserInfoDto updateUserInfoDto);
        UserDto UpdateUserPassword(string email, ChangePasswordDto changePasswordDto);
        User LoginUser(LoginUserDto user);
        List<UserRentBookDto> GetAllUsers();
        UserDto GetUser(string email);
    }
}
