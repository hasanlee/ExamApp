using ExamApp.EntityLayer.DTOs.Lessons;
using ExamApp.EntityLayer.DTOs.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExamApp.EntityLayer.DTOs.Exams
{
    public class ExamAddDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public DateTime ExamDate { get; set; } = DateTime.Now;
        public byte Mark { get; set; }

        [JsonIgnore]
        public IList<StudentDTO> Students { get; set; }
        [JsonIgnore]
        public IList<LessonDTO> Lessons { get; set; }
    }
}
