using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using AutoMapper;
using WebApi.Common;
using WebApi.DataAccess;
using FluentValidation.Results;
using FluentValidation;
using WebApi.Entities;

namespace WebApi.BusinessLogic
{
    public class BookManager
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        BookValidator validator=new BookValidator();
        public BookManager(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> GetAllBooks()
        {
                var bookList=_dbContext.Books.OrderBy(x=>x.Id).ToList();
                List<BooksViewModel> booksListViewModel=_mapper.Map<List<BooksViewModel>>(bookList);
               
                return booksListViewModel;
        }  string message;
        public void AddBook(Book book)
        { 
          
            validator.ValidateAndThrow(book);
            
            // if (results.IsValid)
            // {
                 var existBook=_dbContext.Books.Where(x=>x.Title==book.Title).SingleOrDefault();
            if (existBook is null)
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }
            // }
            // foreach (var item in results.Errors)
            // {
                
            // message =  item.ErrorMessage ;
             
            // }
            // return message;

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
