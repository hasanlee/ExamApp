namespace ExamApp.EntityLayer.DTOs.Students
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public uint StudentNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte ClassNo { get; set; }

        public virtual string FullName
        {
            get
            {
                return Surname + " " + Name;
            }
        }
    }
}
