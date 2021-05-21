using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Core.ApplicationService.Implementation;
using BookStore.Core.ApplicationService.Services;
using BookStore.Core.DomainService;
using Moq;
using Xunit;

namespace BookStoreUnitTest.AppServiceTest
{
   public class AuthorUnitTest
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
        //public void NewAuthorService_WithNullRepository_ShouldThrowException()
        //{
        //    var BookRepoMock = new Mock<IAuthorRepository>();
        //    Action action = () => new AuthorService(null as IAuthorRepository);
        //    action.Should().Throw<NullReferenceException>().WithMessage("Repo Cannot be null");

        //}

        [Fact]
        public void ReadAll_ShouldMatchReadAllInRepository_Once()
        {
            var AuthRepoMock = new Mock<IAuthorRepository>();
            IAuthorService service = new AuthorService(AuthRepoMock.Object);
            AuthRepoMock.Setup(r => r.ReadAllAuthors());
            service.ReadAllAuthors();
            AuthRepoMock.Verify(r => r.ReadAllAuthors(), Times.Once);
            CheckPerformance(() => service.ReadAllAuthors(), 1000);

        }

        [Fact]
        public void GetAuthorById_withNegativeUserId_Once()
        {
            var AuthRepoMock = new Mock<IAuthorRepository>();
            IAuthorService service = new AuthorService(AuthRepoMock.Object);
            AuthRepoMock.Setup(r => r.ReadAuthorById(-1));
            service.ReadAuthorById(-1);
            AuthRepoMock.Verify(r => r.ReadAuthorById(-1), Times.Once);
            CheckPerformance(() => service.ReadAuthorById(-1), 1000);
        }

        [Fact]
        public void Delete_ShouldCallDeleteMethodInRepository_withParamAsId_Once()
        {
            var AuthRepoMock = new Mock<IAuthorRepository>();
            IAuthorService service = new AuthorService(AuthRepoMock.Object);
            AuthRepoMock.Setup(r => r.ReadAuthorById(1));
            service.ReadAuthorById(1);
            AuthRepoMock.Verify(r => r.ReadAuthorById(1), Times.Once);
            CheckPerformance(() => service.DeleteAuthor(1), 1000);
        }
    }
}

