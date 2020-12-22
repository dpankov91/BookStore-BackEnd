using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.Entities;

namespace BookStore.Core.ApplicationService.Services
{
    public interface IGenreService
    {
        List<Genre> ReadAllGenres();

        Genre ReadGenreById(int id);

        Genre CreateGenre(Genre genre);

        Genre DeleteGenre(int id);

        Genre UpdateGenre(Genre genreToUpdate);
    }
}
