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

        public DataInitializer(IGenreRepository genreRepository)
        {
            _genreRepo = genreRepository;
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
        }
    }
}
