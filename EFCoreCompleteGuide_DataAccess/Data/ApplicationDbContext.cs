﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCoreCompleteGuide_Model.Models;
using EFCoreCompleteGuide_DataAccess.FluentConfig;
using Microsoft.Extensions.Logging;

namespace EFCoreCompleteGuide_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }

        // rename it to Fluent_BookDetails using fluent api
        public DbSet<Fluent_BookDetail> BookDetail_Fluent { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EFCoreCompleteGuide;TrustServerCertificate=True;Trusted_Connection=True").LogTo(Console.WriteLine,
                new[] {DbLoggerCategory.Database.Command.Name}, LogLevel.Information );
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            //Composite Key
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new {u.Author_Id,u.Book_Id});
            

            modelBuilder.Entity<Book>().HasData(
                new Book {BookId=1,Title="Spider Without Duty",ISBN="123B12",Price=10.99m, Publisher_Id=1 },
                new Book { BookId = 2, Title = "Fortune Of Time", ISBN = "12123B12", Price = 11.99m, Publisher_Id = 1 });

            var bookList = new Book[] {
                new Book {BookId = 3, Title = "Fake Sunday", ISBN = "77652", Price = 20.99m, Publisher_Id=2 },
                new Book {BookId = 4, Title = "Cookie Jar", ISBN = "CC12B12", Price = 25.99m, Publisher_Id=3 },
                new Book {BookId = 5, Title = "Cloudy Forest", ISBN = "90392B33", Price = 40.99m, Publisher_Id=3 },
            };

            modelBuilder.Entity<Book>().HasData(bookList);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher {Publisher_Id=1,Name="Pub 1 Jimmy",Location="Chicago" },
                 new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "New York" },
                  new Publisher { Publisher_Id = 3, Name = "Pub 3 Ben", Location = "Hawaii" }
                );
        }
    }
}
