using AutoMapper;
using LibraryProject.Application.Constants;
using LibraryProject.Application.Exceptions;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Dto;
using LibraryProject.Domain.Interfaces;
using LibraryProject.Domain.Models;

namespace LibraryProject.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto Register(RegistrationUserDto user, string role)
        {
            var mappedUserRegistration = _mapper.Map<User>(user);

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(mappedUserRegistration.Password);
            mappedUserRegistration.Password = passwordHash;
            mappedUserRegistration.Role = role;

            _userRepository.RegisterUser(mappedUserRegistration);

            var mappedUser = _mapper.Map<UserDto>(mappedUserRegistration);
            return mappedUser;
        }

        public UserDto UpdateUser(string email, UpdateUserInfoDto updateUserInfoDto)
        {
            var updatedUser = _userRepository.GetUser(email);

            if (updatedUser == null)
            {
                throw new NotFoundException("User not found.");
            }

            updatedUser.Username = updateUserInfoDto.Username;

            _userRepository.UpdateUser(updatedUser);

            var mappedUser = _mapper.Map<UserDto>(updatedUser);

            return mappedUser;
        }

        public UserDto UpdateUserPassword(string email, ChangePasswordDto changePasswordDto)
        {
            var updatedPasswordUser = _userRepository.GetUser(email);

            if (updatedPasswordUser == null)
            {
                throw new NotFoundException("User not found");
            }

            string newPasswordHashed = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);
            updatedPasswordUser.Password = newPasswordHashed;
            _userRepository.UpdateUser(updatedPasswordUser);


            var mappedUser = _mapper.Map<UserDto>(updatedPasswordUser);

            return mappedUser;
        }

        public User LoginUser(LoginUserDto user)
        {
            var mappedLoginUser = _mapper.Map<User>(user);

            var getLoggingUser = _userRepository.GetLoggingUser(mappedLoginUser);

            if (getLoggingUser == null)
            {
                throw new NotFoundException("User not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(user.Password, getLoggingUser.Password))
            {
                throw new BadRequestException("Password is invalid");
            }

            return getLoggingUser;
        }

        public List<UserRentBookDto> GetAllUsers()
        {
            var users = _userRepository.GetAll().Where(u => u.Role == LibraryRoles.User).ToList();

            var mappedUsers = _mapper.Map<List<UserRentBookDto>>(users);

            return mappedUsers;
        }

        public UserDto GetUser(string email)
        {
            var user = _userRepository.GetUser(email);

            var mappedUser = _mapper.Map<UserDto>(user);
            return mappedUser;
        }
    }
}
