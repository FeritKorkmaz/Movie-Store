using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands.RemovePursahedMovie
{
    public class RemovePursahedMovieValidator : AbstractValidator<RemovePursahedMovie>
    {
        public RemovePursahedMovieValidator()
        {
            RuleFor(command => command.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.MovieId).NotEmpty().GreaterThan(0);
        }
        
    }
}


