using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStore.Core.DomainService;
using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repositories
{
    public class BookSQLRepository : IBookRepository
    {
        private readonly BookStoreDBContext _ctx;

        public BookSQLRepository(BookStoreDBContext bookStoreDBContext)
        {
            _ctx = bookStoreDBContext;
        }

        public Book CreateBook(Book book)
        {
            _ctx.Attach(book).State = EntityState.Added;
            _ctx.SaveChanges();
            return book;
        }

        public Book DeleteBook(int id)
        {
            var bookToDelete = _ctx.Remove(new Book() { Id = id });
            _ctx.SaveChanges();
            return bookToDelete.Entity;
        }

        public Book GetBookById(int id)
        {
            return _ctx.Books.FirstOrDefault(book => book.Id == id);
        }

        public List<Book> ReadAllBooks()
        {
            return _ctx.Books.ToList();
        }

        public Book UpdateBook(Book bookToUpdate)
        {
            _ctx.Attach(bookToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return bookToUpdate;
        }
    }
}
