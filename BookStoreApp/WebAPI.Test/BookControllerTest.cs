using BookStoreApi.Controllers;
using CoreAbstraction;
using Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WebAPI.Test
{
    public class BookControllerTest : IClassFixture<BaseControllerTest>
    {
        private BooksController _controller;
        public Mock<IBookService> MockBookService { get; set; }
        private List<Book> _books;
        public BookControllerTest(BaseControllerTest fixture)
        {
            MockBookService = fixture.MockBookService;
            _books = new List<Book>();
            _books.Add(new Book() { Title = "1st" });
            _books.Add(new Book() { Title = "2nd" });
            _controller = new BooksController(MockBookService.Object);
        }
        [Fact]
        public void GetTest()
        {
            MockBookService.Setup(x => x.GetAll()).Returns(_books);
            var result = _controller.Get();
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetByIdTest()
        {
            var book = new Book() { Id=1, Title = "1st" };
            MockBookService.Setup(x => x.GetById(1)).Returns(book);
            var result = _controller.Get(1);
            Assert.Equal(1, result.Id);
        }
    }
}
