using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.ApplicationService.Implementation;
using BookStore.Core.ApplicationService.Services;
using BookStore.Core.DomainService;
using BookStore.Core.Entities;
using BookStore.Core.ISecurity;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Xunit;

namespace BookStoreTest.AppService
{
    public class BookStoreUnitTest
    {
        private void CheckPerformance(Action a, int ms)
        {
            DateTime start = DateTime.Now;
            a.Invoke();
            DateTime end = DateTime.Now;
            double time = (end - start).TotalMilliseconds;
            Assert.True(time <= ms);

        }
        //[Fact]
        //public void NewBookService_WithNullRepository_ShouldThrowException()
        //{
        //    var BookRepoMock = new Mock<IBookRepository>();
        //    Action action = () => new BookService(null as IBookRepository);
        //    action.Should().Throw<NullReferenceException>().WithMessage("Repo Cannot be null");

        //}

        [Fact]
        public void ReadAll_ShouldMatchReadAllInRepository_Once()
        { 
           var BookRepoMock = new Mock<IBookRepository>();
           IBookService service = new BookService(BookRepoMock.Object);
           BookRepoMock.Setup(r => r.ReadAllBooks());
           service.ReadAllBooks();
           BookRepoMock.Verify(r => r.ReadAllBooks(),Times.Once);

        }

        [Fact]
        public void GetById_withNegativeUserId_Once()
        {
            var BookRepoMock = new Mock<IBookRepository>();
            IBookService service = new BookService(BookRepoMock.Object);
            BookRepoMock.Setup(r => r.GetBookById(-1));
            service.GetBookById(-1);
            BookRepoMock.Verify(r => r.GetBookById(-1), Times.Once);
        }

        [Fact]
        public void Delete_ShouldCallDeleteMethodInRepository_withParamAsId_Once()
        {
            var BookRepoMock = new Mock<IBookRepository>();
            IBookService service = new BookService(BookRepoMock.Object);
            var deletedBookStore = new Book()
                {Id = 3, Name = ""};
            BookRepoMock.Setup(r => r.DeleteBook(1)).Returns(() => deletedBookStore);
            service.DeleteBook(1 );
            BookRepoMock.Verify(r => r.DeleteBook(1), Times.Once);
        }
    }
}
