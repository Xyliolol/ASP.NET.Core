using FluentValidation;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Validation
{
    public interface IUserDelValidator : IValidationService<UserDeleteModel>
    {

    }
    public class UserDelValidator : FluentValidationService<UserDeleteModel>, IUserDelValidator
    {
        public UserDelValidator()
        {
            RuleFor(x => x.Id)
               .GreaterThan(0)
               .WithErrorCode("D-011");
        }
    }
}
