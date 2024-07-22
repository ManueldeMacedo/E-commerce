using Domain.Entities;
using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class UserCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public UserType UserType { get; set; }

        public static User ToEntity(UserCreateRequest dto)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                UserName = dto.UserName,
                UserType = dto.UserType,
                UserRegistrationDate = DateTime.Now,
                UserDeletionDate = null
            };
        }

        public static bool validateDto(UserCreateRequest dto)
        {
            if (dto.Name == default ||
                dto.Email == default ||
                dto.Password == default ||
                dto.UserName == default)
                return false;

            return true;
        }
    }
}
