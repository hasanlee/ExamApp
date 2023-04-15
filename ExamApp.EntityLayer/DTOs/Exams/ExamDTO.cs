using ExamApp.EntityLayer.DTOs.Lessons;
using ExamApp.EntityLayer.DTOs.Students;

namespace ExamApp.EntityLayer.DTOs.Exams
{
    public class ExamDTO
    {
        public int Id { get; set; }
        public StudentDTO Student { get; set; }
        public LessonDTO Lesson { get; set; }
        public DateTime ExamDate { get; set; } = DateTime.Now;
        public byte Mark { get; set; }
    }
}
