using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace  WebApi.DataAccess
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db=new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
             if (db.Books.Any())
             {
                 return;
             }   
             db.Genres.AddRange(
               new Genre{
                 Name="Personal Growth"
               },
                new Genre{
                 Name="Journey"
               },
                new Genre{
                 Name="History"
               },
                new Genre{
                 Name="Sci-fi"
               }
             );
             db.Books.AddRange(
                 new Book{
              //  Id= 1,
                Title= "Purdy-Mohr",
                GenreId= 1,
                PageCount=357,
                PublishDate= new System.DateTime(2001,06,25)
                },
                new Book {
              //  Id= 2,
                Title= "Bayer Group",
                GenreId=2,
                PageCount= 228,
                PublishDate=  new System.DateTime(2010,10,14)
                }, 
                new Book{
              //  Id= 3,
                Title= "Nolan, Carter and Howell",
                GenreId= 3,
                PageCount= 279,
                PublishDate= new System.DateTime(2014,10,25)
                });
                db.SaveChanges();
            }
        }
    }
    
}