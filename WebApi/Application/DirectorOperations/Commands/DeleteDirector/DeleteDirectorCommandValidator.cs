using FluentValidation;

namespace WebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(command => command.DirectorId).NotEmpty().GreaterThan(0);
        }
    }
}
