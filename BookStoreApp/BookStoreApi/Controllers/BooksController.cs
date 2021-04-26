using CoreAbstraction;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : AbstractController<Book,IBookService>
    {
        // GET: api/<ValuesController>
        public BooksController(IBookService service)
            :base(service)
        {

        }
        protected override void UploadFiles(Book value)
        {
            if (Request.Form.Files.Count > 0)
            {
                var imageFile = Request.Form.Files[0];
                var memoryStream = new MemoryStream();
                imageFile.CopyTo(memoryStream);
                value.Cover = memoryStream.ToArray();
            }
        }
         
    }
}
