using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.DomainService;
using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Data
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IGenreRepository _genreRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IBookRepository _bookRepo;

        public DataInitializer(IGenreRepository genreRepository, IAuthorRepository authorRepository, 
                                        IBookRepository bookRepository)
        {
            _genreRepo = genreRepository;
            _authorRepo = authorRepository;
            _bookRepo = bookRepository;
        }
        public void SeedDB(BookStoreDBContext _ctx)
        {
            #region Geners
            Genre genre1 = new Genre()
            {
                Name = "Novel"
            };
            _genreRepo.CreateGenre(genre1);

            Genre genre2 = new Genre()
            {
                Name = "Fantasy Fiction"
            };
            _genreRepo.CreateGenre(genre2);

            Genre genre3 = new Genre()
            {
                Name = "Biography"
            };
            _genreRepo.CreateGenre(genre3);

            Genre genre4 = new Genre()
            {
                Name = "Fiction"
            };
            _genreRepo.CreateGenre(genre4);

            Genre genre5 = new Genre()
            {
                Name = "Dystopian Fiction"
            };
            _genreRepo.CreateGenre(genre5);

            Genre genre6 = new Genre()
            {
                Name = "Self-help book"
            };
            _genreRepo.CreateGenre(genre6);

            Genre genre7 = new Genre()
            {
                Name = "Satire"
            };
            _genreRepo.CreateGenre(genre7);
            #endregion

            #region Authors
            var author1 = new Author()
            {
                Name = "Paulo Coelho"
            };
            _authorRepo.CreateAuthor(author1);

            var author2 = new Author()
            {
                Name = "Erich Maria Remarque"
            };
            _authorRepo.CreateAuthor(author2);

            var author3 = new Author()
            {
                Name = "George Orwell"
            };
            _authorRepo.CreateAuthor(author3);

            var author4 = new Author()
            {
                Name = "Daniel Keyes"
            };
            _authorRepo.CreateAuthor(author4);

            var author5 = new Author()
            {
                Name = "Jerome David Salinger"
            };
            _authorRepo.CreateAuthor(author5);
            #endregion
        }
    }
}
