using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Core.DomainService;
using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class GenreSQLRepository : IGenreRepository
    {
        private readonly BookStoreDBContext _ctx;

        public GenreSQLRepository(BookStoreDBContext bookStoreDBContext)
        {
            _ctx = bookStoreDBContext;
        }

        public List<Genre> ReadAllGenres()
        {
            return _ctx.Genres.ToList();
        }

        public Genre ReadGenreById(int id)
        {
            return _ctx.Genres.FirstOrDefault(Genre => Genre.Id == id);
        }

        public Genre CreateGenre(Genre genre)
        {
            _ctx.Attach(genre).State = EntityState.Added;
            _ctx.SaveChanges();
            return genre;
        }

        public Genre DeleteGenre(int id)
        {
            var genre = _ctx.Remove(new Genre { Id = id });
            _ctx.SaveChanges();
            return genre.Entity;
        }

        public Genre UpdateGenre(Genre genreToUpdate)
        {
            _ctx.Attach(genreToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return genreToUpdate;
        }
    }
}
