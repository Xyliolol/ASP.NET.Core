using FluentValidation;

namespace WebApp.Validation
{
    public sealed class EmployeeIdValidationService : AbstractValidator<EmployeerModel>
    {
        public EmployeeIdValidationService()
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
    public sealed class EmployeeNameValidationService : AbstractValidator<EmployeerModel>
    {
        public EmployeeNameValidationService()
        {
            RuleFor(x => x.FirstName)
             .NotEmpty()
             .WithMessage("Имя не должно быть пустым")
             .WithErrorCode("N-654");
        }
    }
    public sealed class EmployeeLastNameValidationService : AbstractValidator<EmployeerModel>
    {
        public EmployeeLastNameValidationService()
        {
            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Фамилия не должна быть пустой")
            .WithErrorCode("F-567");
        }
    }
    public sealed class EmployeeEmailValidationService : AbstractValidator<EmployeerModel>
    {
        public EmployeeEmailValidationService()
        {
            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Почта не должна быть пустой")
            .WithErrorCode("M-99");
        }
    }
    public sealed class EmployeeAgeValidationService : AbstractValidator<EmployeerModel>
    {
        public EmployeeAgeValidationService()
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
    public sealed class EmployeeCompanyValidationService : AbstractValidator<EmployeerModel>
    {
        public EmployeeCompanyValidationService()
        {
            RuleFor(x => x.Company)
            .NotEmpty()
            .WithMessage("Компания не должна быть пустой")
            .WithErrorCode("С-100");
        }
    }
}
