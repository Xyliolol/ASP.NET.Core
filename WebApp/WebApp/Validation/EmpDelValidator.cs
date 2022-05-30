using FluentValidation;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Validation
{
    public interface IEmpDelValidator : IValidationService<EmployeerDeleteModel>
    {

    }
    public class EmpDelValidator : FluentValidationService<EmployeerDeleteModel>, IEmpDelValidator
    {
        public EmpDelValidator()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0)
               .WithErrorCode("D-011");
        }
    }
}
