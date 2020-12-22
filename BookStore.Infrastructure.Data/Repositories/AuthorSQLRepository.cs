using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Core.DomainService;
using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class AuthorSQLRepository : IAuthorRepository
    {
        private readonly BookStoreDBContext _ctx;
        public AuthorSQLRepository(BookStoreDBContext bookStoreDBContext)
        {
            _ctx = bookStoreDBContext;
        }

        public List<Author> ReadAllAuthors()
        {
            return _ctx.Authors.ToList();
        }

        public Author ReadAuthorById(int id)
        {
            return _ctx.Authors.FirstOrDefault(author => author.Id == id);
        }

        public Author CreateAuthor(Author author)
        {
            _ctx.Authors.Attach(author).State = EntityState.Added;
            _ctx.SaveChanges();
            return author;
        }

        public Author DeleteAuthor(int id)
        {
            var authorToDelete = _ctx.Authors.Remove(new Author { Id = id });
            _ctx.SaveChanges();
            return authorToDelete.Entity;
        }

         public Author UpdateAuthor(Author authorToUpdate)
         {
            _ctx.Authors.Attach(authorToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return authorToUpdate;
         }
    }
}
