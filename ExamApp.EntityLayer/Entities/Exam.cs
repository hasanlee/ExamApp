using ExamApp.Common.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApp.EntityLayer.Entities
{
    public class Exam:BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public DateTime ExamDate { get; set; } = DateTime.Now;
        public byte Mark { get; set; }
    }
}
