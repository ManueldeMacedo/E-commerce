﻿using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task DeleteAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<List<User>> ListAsync();
        Task UpdateAsync(User user);
    }
}