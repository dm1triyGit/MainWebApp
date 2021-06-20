using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MainContext _context;

        public UserRepository(MainContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User item)
        {
           await _context.Users.AddAsync(item);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User item)
        {
            _context.Users.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> FindAsync(Func<User, bool> predicate)
        {
            var users = Enumerable.Empty<User>();

            await Task.Run(() =>
            {
                users = _context.Users
                   .Include(x => x.Role)
                   .Where(predicate);
            });

            return users;
        }

        public async Task<User> GetAsync(int id)
        {
            return await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include(x => x.Role);
        }

        public async Task UpdateAsync(User item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Role> GetRoleAsync(string roleName)
        {
           return await _context.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
        }
    }
}
