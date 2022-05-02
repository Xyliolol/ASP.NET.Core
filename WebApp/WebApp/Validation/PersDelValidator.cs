using FluentValidation;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Validation
{
    public interface IPersDelValidator : IValidationService<PersonDeleteModel>
    {

    }
    public class PersDelValidator : FluentValidationService<PersonDeleteModel>, IPersDelValidator
    {
        public PersDelValidator()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0)
               .WithErrorCode("D-011");
        }
    }
}
