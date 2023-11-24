using FluentValidation;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.MovieId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Title).MinimumLength(2);
            RuleFor(command => command.Model.DirectorId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Price).NotEmpty().GreaterThan(0);
            
        }
        
    }
}
