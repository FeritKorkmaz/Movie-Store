using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommandValidator : AbstractValidator<CreateTokenCommand>
    {
        public CreateTokenCommandValidator()
        {
            RuleFor(command => command.Model.Email).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(4);
        }
        
    }
}


