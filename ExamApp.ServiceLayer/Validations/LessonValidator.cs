using FluentValidation;
using ExamApp.EntityLayer.Entities;

namespace ExamApp.ServiceLayer.Validations
{
    public class LessonValidator : AbstractValidator<Lesson>
    {
        public LessonValidator()
        {
            RuleFor(x => x.LessonNo).NotEmpty().NotNull().MinimumLength(2).MaximumLength(3);
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.TeacherName).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.TeacherSurname).NotEmpty().NotNull().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.ClassNo).NotEmpty().NotNull().Must(x => x > 0 && x < 100);
        }
    }
}
