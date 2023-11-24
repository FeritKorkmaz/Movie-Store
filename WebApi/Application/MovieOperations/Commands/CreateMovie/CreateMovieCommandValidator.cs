using FluentValidation;

namespace WebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Year).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Price).NotEmpty().GreaterThan("0");
            RuleFor(command => command.Model.ActorsId).NotEmpty().ForEach(x => x.GreaterThan(0));
        }
        
    }
}
