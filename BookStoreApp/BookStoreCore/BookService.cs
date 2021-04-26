using CoreAbstraction;
using DataAbstraction;
using Model;

namespace Core
{
    public class BookService : BaseService<Book, IBookRepository> ,IBookService
    {
        public BookService(IBookRepository repository):base(repository)
        {

        }
    }
}
