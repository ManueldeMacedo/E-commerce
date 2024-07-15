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

        [Required]
        public DateTime UserRegistrationDate { get; set; }

        [Required]
        public DateTime UserDeletionDate { get; set; }

        public static User ToEntity(UserCreateRequest dto)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                UserName = dto.UserName,
                UserType = dto.UserType,
                UserRegistrationDate = dto.UserRegistrationDate,
                UserDeletionDate = dto.UserDeletionDate
            };
        }
    }
}
