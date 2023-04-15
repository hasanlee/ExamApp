using ExamApp.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamApp.DataAccessLayer.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasIndex(x=>x.StudentNo).IsUnique();
            builder.Property(x => x.StudentNo).IsRequired(true).HasMaxLength(5);
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.Surname).HasMaxLength(30).IsRequired(true);
            builder.Property(x => x.ClassNo).HasDefaultValue(0).HasMaxLength(2);

            //Data Seeding
            builder.HasData(
               new Student
               {
                   Id= 1,
                   StudentNo = 12,
                   Name = "Albert",
                   Surname = "Einstein",
                   ClassNo = 1
               }
            );
        }
    }
}
