using FluentValidation;
using WebApi.Entities;

namespace WebApi.BusinessLogic
{
    public class GenreValidator:AbstractValidator<Genre>
    {
            public GenreValidator()
            {
                RuleFor(x=>x.Id).GreaterThan(0);
                RuleFor(x=>x.Name).NotEmpty().MinimumLength(4);
                
            }
    }
}