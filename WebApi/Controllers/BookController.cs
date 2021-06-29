using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.BusinessLogic;
using WebApi.DataAccess;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class BookController:ControllerBase
    { 
       private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            BookManager  _manager=new BookManager(_context);
           var result=  _manager.GetAllBooks();
           return Ok(result);

        }
        [HttpGet("getbyid")]
        public Book GetById(int id)
        {
            var book=_context.Set<Book>().Where(x=>x.Id==id).FirstOrDefault();
            return book;
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
             BookManager  _manager=new BookManager(_context);
             _manager.AddBook(book);
             return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBook(Book updatedbook)
        {
                var book=_context.Set<Book>().Where(x=>x.Id==updatedbook.Id).SingleOrDefault();
             if (book==null)
            {
              return BadRequest();
            }
            book.Title=updatedbook.Title!= default ? updatedbook.Title: book.Title;
            book.GenreId=updatedbook.GenreId!= default ? updatedbook.GenreId: book.GenreId;
            book.PageCount=updatedbook.PageCount!= default ? updatedbook.PageCount: book.PageCount;
            book.PublishDate=updatedbook.PublishDate!= default ? updatedbook.PublishDate: book.PublishDate;
             _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("deletebook")]
        public IActionResult DeleteBook(int id)
        { 
            var book=_context.Set<Book>().Where(x=>x.Id==id).SingleOrDefault();
        if (book is null)
        {
            return BadRequest();
        }
            _context.Books.Remove(book); 
            _context.SaveChanges();
            return Ok();
        }

    }
    
}