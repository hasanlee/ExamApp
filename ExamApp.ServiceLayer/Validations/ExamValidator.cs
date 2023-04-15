using ExamApp.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.ServiceLayer.Validations
{
    public class ExamValidator : AbstractValidator<Exam>
    {
        public ExamValidator()
        {
            RuleFor(x => x.ExamDate).NotEmpty().NotNull();
            RuleFor(x => x.Mark).NotEmpty().NotNull();
        }
    }
}
