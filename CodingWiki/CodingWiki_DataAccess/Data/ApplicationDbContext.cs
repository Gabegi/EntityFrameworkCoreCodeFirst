using CodingWiki_DataAccess.FluentConfigs;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }   
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Fluent_BookDetail> BookDetails_Fluent_ { get; set; }

        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            // Uncomment for local DB

            //optionsBuilder.UseSqlServer(@"Server=DVT-CHANGEMENOW\SQLEXPRESS;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;")
            //    .LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API, folder FluentConfigs = best practice
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            

            // Alternative, write Fluent API here
            modelBuilder.Entity<Fluent_BookAuthorMap>()
                        .HasKey(ba => new
                        {
                            ba.Book_Id,
                            ba.Author_Id
                        });
            
            modelBuilder.Entity<Fluent_BookAuthorMap>()
                        .HasOne(b => b.Book)
                        .WithMany(ba => ba.BookAuthorMap)
                        .HasForeignKey(b => b.Book_Id);
            
            modelBuilder.Entity<Fluent_BookAuthorMap>()
                        .HasOne(a => a.Author)
                        .WithMany(ba => ba.BookAuthorMap)
                        .HasForeignKey(a => a.Author_Id);
            
            modelBuilder.Entity<Fluent_Book>()
                        .HasOne(u => u.Publisher)
                        .WithMany(u => u.Books)
                        .HasForeignKey(u => u.Publisher_Id); // FK always in entity that has the 1 side of the 1-many relationship


            
            
            
            
            modelBuilder.Entity<Category>()
                        .Ignore(c => c.DiscountedPrice);

            modelBuilder.Entity<Category>()
                        .Property(c => c.CategoryName)
                        .HasMaxLength(50);

            modelBuilder.Entity<Category>()
                        .HasKey(c => c.CategoryId);


            modelBuilder.Entity<Category>()
                        .Property(c => c.Title)
                        .IsRequired();


            modelBuilder.Entity<Category>()
                        .Property(c => c.ISBN)
                        .HasColumnName("ISBN_Name");

            modelBuilder.Entity<Fluent_BookDetail>()
                        .Property(c => c.NumberOfChapters)
                        .HasColumnName("NoOfChapters");


            modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");

            modelBuilder.Entity<Category>().ToTable("tb_Category");
            
            modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10, 5);

            modelBuilder.Entity<BookAuthorMap>()
                .HasKey(ba => new 
                { ba.Book_Id, 
                  ba.Author_Id 
                });



            modelBuilder.Entity<Book>().HasData(
                    new Book
                    {
                        BookId = 1,
                        Title = "Professional C# 7 and .NET Core 2.0",
                        ISBN = "978-1-119-44926-0",
                        Price = 45.00M,
                        Publisher_Id = 1
                    }
                    );

            var bookList = new Book[]
            {
                new Book { BookId = 2, ISBN = "978-1-119-44926-0", Title = "Professional C# 7 and .NET Core 2.0", Price = 45.00M, Publisher_Id = 2 },
                new Book { BookId = 3, ISBN = "978-1-119-44926-0", Title = "Professional C# 7 and .NET Core 2.0", Price = 45.00M, Publisher_Id = 3 },
                new Book { BookId = 4, ISBN = "978-1-119-44926-0", Title = "Professional C# 7 and .NET Core 2.0", Price = 45.00M, Publisher_Id = 3 },
            };
            // add a list of Book objects
            modelBuilder.Entity<Book>().HasData(bookList);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Location = "USA", Name = "Wrox Press", Publisher_Id = 1 },
                new Publisher { Location = "UK", Name = "Wrox Press", Publisher_Id = 2 },
                new Publisher { Location = "Fr", Name = "Bob Press", Publisher_Id = 3 }
                );
        }
    }
}
