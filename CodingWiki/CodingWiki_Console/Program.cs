using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
    }
}




//using(ApplicationDbContext context = new ())
//{
//    context.Database.EnsureCreated();

//    if(context.Database.GetPendingMigrations().Any())
//    {
//        context.Database.Migrate();
//    }
//}

// create method get all books

//GetAllBooks();

//void GetAllBooks()
//{
//    using ApplicationDbContext context = new();
//    var books = context.Books.ToList();
//    foreach (var book in books)
//    {
//        Console.WriteLine(book.Title);
//    }
//}

//void CreateBook()
//{
//    using ApplicationDbContext context = new();
//    var book = new Book()
//    {
//        Title = "C# in Depth",
//        ISBN = "123456789",
//        Publisher_Id = 1
//    };
//    context.Books.Add(book);
//    context.SaveChanges();
//}   
