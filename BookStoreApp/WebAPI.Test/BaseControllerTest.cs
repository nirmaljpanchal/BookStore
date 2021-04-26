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

        public BaseControllerTest()
        {
            MockBookService = new Mock<IBookService>();
        }

        public void Dispose()
        {
        }
    }
}
