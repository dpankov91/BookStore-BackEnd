using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime PublishDate { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
