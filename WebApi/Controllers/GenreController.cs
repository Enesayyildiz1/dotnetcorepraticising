using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.BusinessLogic;
using AutoMapper;
using WebApi.DataAccess;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class GenreController:ControllerBase
    { 
       private readonly BookStoreDbContext _context;
       private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
          
        [HttpGet]
        public IActionResult GetGenres()
        {
          GenreManager  _manager=new GenreManager(_context,_mapper);
           var result=  _manager.GetAllGenres();
           return Ok(result);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {GenreManager  _manager=new GenreManager(_context,_mapper);
            var genre=_manager.GetById(id);
           return Ok(genre);
        }
        [HttpPost]
        public IActionResult AddGenre(Genre genre)
        {
           
            GenreManager  _manager=new GenreManager(_context,_mapper);
            // var error=
            _manager.AddGenre(genre);
            // if (error is not null)
            // {
            //     return BadRequest(error);
            // }
             return Ok();
        }
        [HttpPut]
        public IActionResult UpdateGenre(Genre genre)
        {GenreManager  _manager=new GenreManager(_context,_mapper);
            _manager.UpdateGenre(genre);
            return Ok();
        }
        [HttpDelete("deletebook")]
        public IActionResult DeleteGenre(int id)
        { GenreManager  _manager=new GenreManager(_context,_mapper);
           _manager.DeleteGenre(id);
            return Ok();
        }
    }
    
}