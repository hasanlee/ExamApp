using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExamApp.EntityLayer.Entities;

namespace ExamApp.DataAccessLayer.Mappings
{
    public class LessonMapping : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasIndex(x => x.LessonNo).IsUnique();
            builder.Property(x => x.LessonNo).HasMaxLength(3).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.ClassNo).HasDefaultValue(0).HasMaxLength(2);
            builder.Property(x => x.TeacherName).HasMaxLength(20).IsRequired(true);
            builder.Property(x => x.TeacherSurname).HasMaxLength(20);

            //Data Seeding
            builder.HasData(new Lesson
            {
                Id= 1,
                LessonNo = "L01",
                Name = "Lesson 1",
                ClassNo = 1,
                TeacherName = "John",
                TeacherSurname = "Doe"
            });
        }
    }
}
