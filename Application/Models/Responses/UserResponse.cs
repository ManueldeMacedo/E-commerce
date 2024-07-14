using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;

namespace Application.Models.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; }
        public DateTime UserRegistrationDate { get; set; }
        public DateTime UserDeletionDate { get; set; }

        public static UserResponse ToDto(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserName = user.UserName,
                UserType = user.UserType,
                UserRegistrationDate = user.UserRegistrationDate,
                UserDeletionDate = user.UserDeletionDate
            };
        }

        public static User ToEntity(UserResponse dto)
        {
            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                UserName = dto.UserName,
                UserType = dto.UserType,
                UserRegistrationDate = dto.UserRegistrationDate,
                UserDeletionDate = dto.UserDeletionDate
            };
        }

        public static List<UserResponse> ToList(IEnumerable<User> users)
        {
            var listUserDto = new List<UserResponse>();
            foreach (var user in users)
            {
                listUserDto.Add(ToDto(user));
            }
            return listUserDto;
        }
    }
}
