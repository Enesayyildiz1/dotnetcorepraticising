using FluentValidation;
using WebApi.Entities;

namespace WebApi.BusinessLogic
{
    public class BookValidator:AbstractValidator<Book>
    {
            public BookValidator()
            {
                RuleFor(x=>x.PageCount).GreaterThan(0);
                RuleFor(x=>x.Title).NotEmpty().MinimumLength(4);
                RuleFor(x=>x.PublishDate.Date).NotEmpty().LessThan(System.DateTime.Now.Date);
                RuleFor(x=>x.GenreId).GreaterThan(0);
            }
    }
}