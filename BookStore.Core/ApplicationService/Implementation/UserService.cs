using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.ApplicationService.Services;
using BookStore.Core.DomainService;
using BookStore.Core.Entities;

namespace BookStore.Core.ApplicationService.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User CreateUser(User user)
        {
            return _userRepo.CreateUser(user);
        }

        public User DeleteUser(int id)
        {
            return _userRepo.DeleteUser(id);
        }


        public User UpdateUser(User userToUpdate)
        {
            return _userRepo.UpdateUser(userToUpdate);
        }

    }
}
