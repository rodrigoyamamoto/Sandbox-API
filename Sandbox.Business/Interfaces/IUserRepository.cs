using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sandbox.Business.Models;

namespace Sandbox.Business.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> ListAsync();
    }
}