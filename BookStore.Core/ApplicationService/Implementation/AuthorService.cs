using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.ApplicationService.Services;
using BookStore.Core.DomainService;
using BookStore.Core.Entities;

namespace BookStore.Core.ApplicationService.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepo = authorRepository;
        }

        public List<Author> ReadAllAuthors()
        {
            return _authorRepo.ReadAllAuthors();
        }

        public Author ReadAuthorById(int id)
        {
            return _authorRepo.ReadAuthorById(id);
        }

        public Author CreateAuthor(Author author)
        {
            return _authorRepo.CreateAuthor(author);
        }

        public Author DeleteAuthor(int id)
        {
            return _authorRepo.DeleteAuthor(id);
        }

        public Author UpdateAuthor(Author authorToUpdate)
        {
            return _authorRepo.UpdateAuthor(authorToUpdate);
        }
    }
}
