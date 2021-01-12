using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sandbox.Business.Interfaces;
using Sandbox.Business.Models;
using Sandbox.Data.Context;

namespace Sandbox.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}