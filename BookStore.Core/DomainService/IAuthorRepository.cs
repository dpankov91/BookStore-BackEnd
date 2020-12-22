using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.Entities;

namespace BookStore.Core.DomainService
{
    public interface IAuthorRepository
    {
        List<Author> ReadAllAuthors();
        Author ReadAuthorById(int id);
        Author CreateAuthor(Author author);
        Author DeleteAuthor(int id);
        Author UpdateAuthor(Author authorToUpdate);
    }
}
