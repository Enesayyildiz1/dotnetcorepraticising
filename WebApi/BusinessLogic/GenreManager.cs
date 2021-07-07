using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using WebApi.DataAccess;
using WebApi.Entities;

namespace WebApi.BusinessLogic
{
    public class GenreManager
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
       // GenreValidator validator=new GenreValidator();
        public GenreManager(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        GenreValidator validator=new GenreValidator();
        public List<GenresViewModel> GetAllGenres()
        {
            var genres=_dbContext.Genres.Where(x=>x.IsActive).OrderBy(x=>x.Id);
            List<GenresViewModel> returnObj=_mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        } 
        public Genre GetById(int id)
        {
            var genre=_dbContext.Set<Genre>().Where(x=>x.Id==id).FirstOrDefault();
            if (genre is null)
            {
                throw new InvalidOperationException("Kategori bulunamadı");
            }
            return genre;
        }
        public void AddGenre(Genre genre)
        { 
          
            validator.ValidateAndThrow(genre);
            
            // if (results.IsValid)
            // {
            var existBook=_dbContext.Genres.Where(x=>x.Name==genre.Name).SingleOrDefault();
            if (existBook is not null)
            {
                throw new InvalidOperationException("Kategori zaten mevcut");
            }
            else
            {
                
                _dbContext.Genres.Add(genre);
                _dbContext.SaveChanges();
            }    
            // }
            // foreach (var item in results.Errors)
            // {
                
            // message =  item.ErrorMessage ;
             
            // }
            // return message;

        }
      
        public void UpdateGenre(Genre updatedgenre)
        { 
            validator.ValidateAndThrow(updatedgenre);
           var genre=_dbContext.Set<Genre>().Where(x=>x.Id==updatedgenre.Id).SingleOrDefault();
            if (genre==null)
            {
               throw new InvalidOperationException("Kategori bulunamadı");
            }
            genre.Name=updatedgenre.Name!= default ? updatedgenre.Name: genre.Name;
            genre.IsActive=updatedgenre.IsActive!= default ? updatedgenre.IsActive: genre.IsActive;
          
            _dbContext.SaveChanges();
        

        }
         public void DeleteGenre(int id)
        { 
            var genre=_dbContext.Set<Genre>().Where(x=>x.Id==id).SingleOrDefault();
        if (genre is null)
        {
           throw new InvalidOperationException("Kategori bulunamadı");
        }
            _dbContext.Genres.Remove(genre); 
            _dbContext.SaveChanges();
           
        }

    } 
    public class GenresViewModel
    {
        public int Id { get; set; }     
        public string Name { get; set; }     
      
    }
}