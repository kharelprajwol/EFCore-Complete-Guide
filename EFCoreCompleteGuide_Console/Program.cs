// See https://aka.ms/new-console-template for more information
using EFCoreCompleteGuide_DataAccess.Data;
using EFCoreCompleteGuide_Model.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

//using (ApplicationDbContext context = new()) 
//{
//    context.Database.EnsureCreated();
//    if (context.Database.GetPendingMigrations().Count() > 0) 
//    {
//        context.Database.Migrate();
//    }
//}

//AddBook();
//GetAllBooks();
//GetBook();
//UpdateBook();
DeleteBook();

void DeleteBook()
{
    using var context = new ApplicationDbContext();
    var book = context.Books.Find(2);
    //Console.WriteLine(book.Title + " - " + book.Price);
    context.Books.Remove(book);
   context.SaveChanges();   

}

void UpdateBook()
{
    using var context = new ApplicationDbContext();

    //var book = context.Books.Find(2);
    //Console.WriteLine(book.Title + " - " + book.ISBN);
    //book.ISBN = "777";
    //Console.WriteLine(book.Title + " - " + book.ISBN);
    //context.SaveChanges();

    var books = context.Books.Where(u => u.Publisher_Id == 1);
    foreach(var book in books)
    {
        book.Price = 55;
        Console.WriteLine(book.Title + " - " + book.Price);
    }
    context.SaveChanges();
    Console.WriteLine("Database updated Successfully");


}

void GetBook()
{
    using var context = new ApplicationDbContext();

    //var input = "Cookie Jar";
    //var book = context.Books.FirstOrDefault(u => u.Title == input);
    //var books = context.Books.Where(u => u.ISBN.Contains("12"));
    //var books = context.Books.OrderBy(u => u.Title).ThenByDescending(u => u.ISBN);
    //var books = context.Books.Where(u => u.Price > 11). OrderBy(u => u.Title).ThenByDescending(u => u.ISBN);
    // var books = context.Books.Skip(4).Take(1);

    var books = context.Books.Skip(4).Take(1);
    foreach (var book in books)
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }


    //Console.WriteLine(book.Title + " - " + book.ISBN);
}

void GetAllBooks()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.ToList();
    foreach (var book in books) 
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
    
}

void AddBook()
{
    Book book = new Book { Title="New EF Core Book", ISBN="121212121", Price=10.93m, Publisher_Id=1 };
    using var context = new ApplicationDbContext();
    context.Books.Add(book);
    context.SaveChanges();
}