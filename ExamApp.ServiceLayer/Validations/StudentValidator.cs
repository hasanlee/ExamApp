using ExamApp.EntityLayer.Entities;
using FluentValidation;

namespace ExamApp.ServiceLayer.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.Surname).NotEmpty().NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.StudentNo).NotEmpty().NotNull().Must(x => x > 0 && x <= 99999);
            RuleFor(x => x.ClassNo).NotEmpty().NotNull().Must(x => x > 0 && x < 100);
        }

    }
}
