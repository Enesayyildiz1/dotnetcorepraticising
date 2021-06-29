using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.Common;
using WebApi.DataAccess;

namespace WebApi.BusinessLogic
{
    public class BookManager
    {
        private readonly BookStoreDbContext _dbContext;

        public BookManager(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> GetAllBooks()
        {
                var bookList=_dbContext.Books.OrderBy(x=>x.Id).ToList();
                List<BooksViewModel> booksListViewModel=new List<BooksViewModel>();
                foreach (var book in bookList)
                {
                    booksListViewModel.Add(new BooksViewModel()
                    {
                        Title=book.Title,
                        Genre=((GenreEnum)book.GenreId).ToString(),
                        PageCount=book.PageCount,
                        DateTime=book.PublishDate.Date.ToString("yyyy/mm/dd")
                        
                    });
                }
                return booksListViewModel;
        }
        public void AddBook(Book book)
        {
            var existBook=_dbContext.Books.Where(x=>x.Title==book.Title).SingleOrDefault();
            if (existBook is null)
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }

        }
    }
    public class BooksViewModel
    {
        public string Title { get; set; }     
        public string Genre { get; set; }     
        public int PageCount { get; set; }
        public string DateTime { get; set; } 
    }
}
