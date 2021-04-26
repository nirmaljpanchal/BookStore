using DataAbstraction;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BookRepository : BaseRepository<Book>,IBookRepository
    {
        public BookRepository(BookStoreContext dbContext):base(dbContext)
        { }
    }
}
