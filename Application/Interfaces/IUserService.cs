using Application.Models;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        ICollection<UserResponse> GetAllUsers();
        UserResponse GetUserById(int id);

        User GetUserByUserName(string userName);
        void UpdateUser(int id, UserCreateRequest customer);
        void DeleteUser(int id);
        UserResponse CreateUser(UserCreateRequest user);
    }
}