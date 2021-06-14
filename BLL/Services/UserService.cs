using AutoMapper;
using BLL.Constants;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<UserService> logger
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public bool Create(UserDTO item)
        {
            try
            {
                if (item == null || item.RoleId == default)
                {
                    throw new NullReferenceException();
                }

                var user = _mapper.Map<UserDTO, User>(item);
                _userRepository.Create(user);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ErrorMessageConstants.CreateErrorMessage);
                return false;
            }
            return true;
        }

        public bool Delete(UserDTO item)
        {
            try
            {
                if (item == null)
                {
                    throw new NullReferenceException();
                }

                var user = _mapper.Map<UserDTO, User>(item);
                _userRepository.Delete(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessageConstants.DeleteErrorMessage);
                return false;
            }
            return true;
        }

        public IEnumerable<UserDTO> Find(Func<User, bool> predicate)
        {
            var usersDTO = new List<UserDTO>();

            try
            {
                var users = _userRepository.Find(predicate);
                usersDTO = _mapper.Map<IEnumerable<User>, List<UserDTO>>(users); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessageConstants.GetErrorMessage);
                return null;
            }

            return usersDTO;
        }

        public UserDTO Get(int id)
        {
            var userDTO = new UserDTO();

            try
            {
                var user = _userRepository.Get(id);
                userDTO = _mapper.Map<User, UserDTO>(user);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ErrorMessageConstants.GetErrorMessage);
                return null;
            }

            return userDTO;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var usersDTO = new List<UserDTO>();

            try
            {
                var users = _userRepository.GetAll();
                usersDTO = _mapper.Map<IEnumerable<User>, List<UserDTO>>(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessageConstants.GetErrorMessage);
                return null;
            }

            return usersDTO;
        }

        public bool Update(UserDTO item)
        {
            throw new NotImplementedException();
        }

        public RoleDTO GetRoleByName(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return null;
            }

            var roleDTO = new RoleDTO();

            try
            {
                var role = _userRepository.GetRole(roleName);
                roleDTO = _mapper.Map<Role, RoleDTO>(role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessageConstants.GetErrorMessage);
                return null;
            }

            return roleDTO;
        }
    }
}
