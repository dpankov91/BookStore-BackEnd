using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.Entities;

namespace BookStore.Core.ApplicationService.Services
{
    public interface IAuthorService
    {
        List<Author> ReadAllAuthors();

        Author ReadAuthorById(int id);

        Author CreateAuthor(Author author);

        Author DeleteAuthor(int id);

        Author UpdateAuthor(Author authorToUpdate);
    }
}
