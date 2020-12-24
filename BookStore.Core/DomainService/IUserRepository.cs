using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.Entities;

namespace BookStore.Core.DomainService
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();

        User GetUserById(int id);

        User CreateUser(User user);

        User DeleteUser(int id);

        User UpdateUser(User userToUpdate);
    }
}
