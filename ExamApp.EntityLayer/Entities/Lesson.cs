using System.ComponentModel.DataAnnotations.Schema;
using ExamApp.Common.Entities;

namespace ExamApp.EntityLayer.Entities
{
    public class Lesson:BaseEntity
    {
        public string LessonNo { get; set; }
        public string Name { get; set; }
        public byte ClassNo { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
