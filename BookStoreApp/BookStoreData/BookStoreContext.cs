using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions options): base(options) {
        
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Seed();
        }

    }
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book()
            {
                Id = 1,
                Title = "Star Wars I",
                Description = "Description of Star Wars I",
                Author = "Skywalker",

            }, new Book()
            {
                Id = 2,
                Title = "Star Wars II",
                Description = "Description of Star Wars II",
                Author = "SkywalkerII",

            });
        }
    }
}
