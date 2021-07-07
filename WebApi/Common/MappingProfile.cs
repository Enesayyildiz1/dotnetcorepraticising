using AutoMapper;
using WebApi.BusinessLogic;
using WebApi.Entities;

namespace  WebApi.Common
{
    public class MappingProfile:Profile
    {
            public MappingProfile()
            {
                CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));

                CreateMap<Genre,GenresViewModel>();
            }
    }
    
}