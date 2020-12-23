using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.Entities;

namespace BookStore.Core.DomainService
{
    public interface IBookRepository
    {
        List<Book> ReadAllBooks();
        Book GetBookById(int id);
        Book CreateBook(Book book);
        Book DeleteBook(int id);
        Book UpdateBook(Book bookToUpdate);
    }
}
