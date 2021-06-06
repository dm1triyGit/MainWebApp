using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        public void Create(UserDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> Find(Func<UserDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public UserDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
