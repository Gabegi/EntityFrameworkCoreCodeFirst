using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }   
        public DbSet<BookDetail> BookDetails { get; set; }   




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DVT-CHANGEMENOW\SQLEXPRESS;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10, 5);

            modelBuilder.Entity<Book>().HasData(
                    new Book
                    {
                        BookId = 1,
                        Title = "Professional C# 7 and .NET Core 2.0",
                        ISBN = "978-1-119-44926-0",
                        Price = 45.00M
                    }
                    );

            var bookList = new Book[]
            {
                new Book { BookId = 2, ISBN = "978-1-119-44926-0", Title = "Professional C# 7 and .NET Core 2.0", Price = 45.00M },
                new Book { BookId = 3, ISBN = "978-1-119-44926-0", Title = "Professional C# 7 and .NET Core 2.0", Price = 45.00M },
                new Book { BookId = 4, ISBN = "978-1-119-44926-0", Title = "Professional C# 7 and .NET Core 2.0", Price = 45.00M },
            };
            // add a list of Book objects
            modelBuilder.Entity<Book>().HasData(bookList);
        }


        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{
        //}
    }
}
