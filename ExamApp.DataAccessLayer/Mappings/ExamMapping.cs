using ExamApp.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamApp.DataAccessLayer.Mappings
{
    public class ExamMapping : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(x => x.LessonId).IsRequired(true).HasMaxLength(3);
            builder.Property(x => x.StudentId).IsRequired(true).HasMaxLength(5);
            builder.Property(x => x.ExamDate).IsRequired(true).HasColumnType("date");
            builder.Property(x => x.Mark).HasDefaultValue(0).HasMaxLength(1);

            //Data Seeding
            builder.HasData(new Exam
            {
                Id = 1,
                LessonId = 1,
                StudentId = 1,
                ExamDate = DateTime.Now,
                Mark = 5
            });
        }
    }
}
