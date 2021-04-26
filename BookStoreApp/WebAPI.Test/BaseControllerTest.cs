using AutoMapper;
using BookStoreApi.MappingProfiles;
using CoreAbstraction;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Test
{
    public class BaseControllerTest : IDisposable
    {
        public Mock<IBookService> MockBookService { get; set; }
        public IMapper Mapper { get; set; }
        public BaseControllerTest()
        {
            MockBookService = new Mock<IBookService>();
            var mockMapper = new MapperConfiguration(cfg=>
            cfg.AddProfile(new DomainToResponseProfile()));
            Mapper = mockMapper.CreateMapper();
        }

        public void Dispose()
        {
        }
    }
}
