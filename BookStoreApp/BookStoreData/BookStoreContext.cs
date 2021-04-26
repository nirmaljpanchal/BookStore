using Microsoft.EntityFrameworkCore;
using Model;


namespace Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions options): base(options) {
        
        }
        public DbSet<Book> Books { get; set; }

    }
}
