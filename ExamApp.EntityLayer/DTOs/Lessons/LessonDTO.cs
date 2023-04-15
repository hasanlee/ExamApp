namespace ExamApp.EntityLayer.DTOs.Lessons
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public string LessonNo { get; set; }
        public string Name { get; set; }
        public byte ClassNo { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }

        public virtual string TeacherFullName
        {
            get
            {
                return TeacherSurname + " " + TeacherName;
            }
        }
    }
}