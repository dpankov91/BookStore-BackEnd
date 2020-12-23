using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.ApplicationService.Services;
using BookStore.Core.DomainService;
using BookStore.Core.Entities;

namespace BookStore.Core.ApplicationService.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }
        public List<Book> ReadAllBooks()
        {
            return _bookRepo.ReadAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _bookRepo.GetBookById(id);
        }

        public Book CreateBook(Book book)
        {
            return _bookRepo.CreateBook(book);
        }

        public Book DeleteBook(int id)
        {
            return _bookRepo.DeleteBook(id);
        }

        public Book UpdateBook(Book bookToUpdate)
        {
            return _bookRepo.UpdateBook(bookToUpdate);
        }
    }
}
