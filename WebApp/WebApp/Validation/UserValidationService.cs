using FluentValidation;
using WebApp.Models;

namespace WebApp.Validation
{
    public sealed class UserIdValidationService : AbstractValidator<UserModel>
    {
        public UserIdValidationService()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage("Id не можен быть пустым")
              .WithErrorCode("I-654");
            RuleFor(x => x.Id)
           .GreaterThan(0)
            .WithMessage("Id не можен быть равен 0")
            .WithErrorCode("I-456");
        }
    }
    public sealed class UserNameValidationService : AbstractValidator<UserModel>
    {
        public UserNameValidationService()
        {
            RuleFor(x => x.FirstName)
             .NotEmpty()
             .WithMessage("Имя не должно быть пустым")
             .WithErrorCode("N-654");
        }
    }
    public sealed class UserLastNameValidationService : AbstractValidator<UserModel>
    {
        public UserLastNameValidationService()
        {
            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Фамилия не должна быть пустой")
            .WithErrorCode("F-567");
        }
    }
    public sealed class UserEmailValidationService : AbstractValidator<UserModel>
    {
        public UserEmailValidationService()
        {
            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Почта не должна быть пустой")
            .WithErrorCode("M-99");
        }
    }
    public sealed class UserAgeValidationService : AbstractValidator<UserModel>
    {
        public UserAgeValidationService()
        {
            RuleFor(x => x.Age)
           .NotEmpty()
           .WithMessage("Возраст не должен быть пустым")            
           .WithErrorCode("A-321");
            RuleFor(x => x.Age)
           .GreaterThan(18)
            .WithMessage("Возраст не должен быть менее 18")
           .WithErrorCode("A-123");
        }
    }
    
}
