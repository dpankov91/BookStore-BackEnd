using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Core.DomainService;
using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class UserSQLRepository : IUserRepository
    {
        private readonly BookStoreDBContext _ctx;

        public UserSQLRepository(BookStoreDBContext bookStoreDBContext)
        {
            _ctx = bookStoreDBContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _ctx.Users.FirstOrDefault(user => user.Id == id);
        }

        public User CreateUser(User user)
        {
            _ctx.Attach(user).State = EntityState.Added;
            _ctx.SaveChanges();
            return user;
        }

        public User DeleteUser(int id)
        {
            var user = _ctx.Remove(new User() { Id = id });
            _ctx.SaveChanges();
            return user.Entity;
        }

        public User UpdateUser(User userToUpdate)
        {
            _ctx.Attach(userToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return userToUpdate;
        }
    }
}
