using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MainContext _context;

        public UserRepository(MainContext context)
        {
            _context = context;
        }

        public void Create(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public void Delete(User item)
        {
            _context.Users.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _context.Users
                .Include(x => x.Role)
                .Where(predicate);
        }

        public User Get(int id)
        {
            return _context.Users
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include(x => x.Role);
        }

        public void Update(User item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }

        public Role GetRole(string roleName)
        {
           return _context.Roles.FirstOrDefault(x => x.Name == roleName);
        }
    }
}
