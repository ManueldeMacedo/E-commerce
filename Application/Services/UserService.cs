using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICollection<UserResponse> GetAllUsers()
        {
            var users = UserResponse.ToList(_userRepository.ListAsync().Result ?? throw new Exception("No se encontraron usuarios"));
            return users;
        }

        public UserResponse GetUserById(int id)
        {
            UserResponse userResponse = UserResponse.ToDto(_userRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontró el usuario"));
            return userResponse;
        }

        public UserResponse CreateUser(UserCreateRequest dto)
        {
            return UserResponse.ToDto(_userRepository.AddAsync(UserCreateRequest.ToEntity(dto)).Result);
        }

        public void UpdateUser(int id, UserCreateRequest userDto)
        {
            var user = _userRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontró el usuario");
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.UserName = userDto.UserName;
            user.UserType = userDto.UserType;
            user.UserRegistrationDate = userDto.UserRegistrationDate;
            user.UserDeletionDate = userDto.UserDeletionDate;
            _userRepository.UpdateAsync(user);
        }

        public void DeleteUser(int id)
        {
            var userDto = _userRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontró el usuario");
            _userRepository.DeleteAsync(userDto);
        }
    }
}
