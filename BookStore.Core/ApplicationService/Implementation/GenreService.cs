using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.ApplicationService.Services;
using BookStore.Core.DomainService;
using BookStore.Core.Entities;

namespace BookStore.Core.ApplicationService.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepo;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepo = genreRepository;
        }

        public List<Genre> ReadAllGenres()
        {
            return _genreRepo.ReadAllGenres();
        }

        public Genre ReadGenreById(int id)
        {
            return _genreRepo.ReadGenreById(id);
        }

        public Genre CreateGenre(Genre genre)
        {
            return _genreRepo.CreateGenre(genre);
        }

        public Genre DeleteGenre(int id)
        {
            return _genreRepo.DeleteGenre(id);
        }

        public Genre UpdateGenre(Genre genreToUpdate)
        {
            return _genreRepo.UpdateGenre(genreToUpdate);
        }
    }
}
