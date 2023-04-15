using ExamApp.Common.Entities;

namespace ExamApp.EntityLayer.Entities
{
    public class Student:BaseEntity
    {
        public uint StudentNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte ClassNo { get; set; }
        public ICollection<Exam> Exams { get; set; }

    }
}
