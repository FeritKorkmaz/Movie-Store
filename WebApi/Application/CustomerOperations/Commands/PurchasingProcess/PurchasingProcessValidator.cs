using FluentValidation;

namespace WebApi.Application.CustomerOperations.Commands.PurchasingProcess
{
    public class PurchasingProcessValidator : AbstractValidator<PurchasingProcess>
    {
        public PurchasingProcessValidator()
        {
            RuleFor(command => command.Model.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.MovieId).NotEmpty().GreaterThan(0);
        }
        
    }
}


