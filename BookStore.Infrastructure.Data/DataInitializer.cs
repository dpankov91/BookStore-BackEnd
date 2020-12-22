using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Data
{
    public class DataInitializer : IDataInitializer
    {
        public void SeedDB(BookStoreDBContext _ctx)
        {
            Genre genre1 = _ctx.Genres.Add(new Genre()
            {
                Name = "Fiction"
            }).Entity;

            Genre genre2 = _ctx.Genres.Add(new Genre()
            {
                Name = "Novel"
            }).Entity; 

            _ctx.Genres.Add(new Genre()
            {
                Name = "Mystery"
            }); 

            _ctx.Genres.Add(new Genre()
            {
                Name = "Biography"
            });
        }
    }
}
