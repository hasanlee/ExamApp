using ExamApp.EntityLayer.DTOs.Students;

namespace ExamApp.ServiceLayer.Services.Contracts
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<bool> CreateStudentAsync(StudentDTO studentDTO);
        Task<bool> UpdateStudentAsync(StudentDTO studentDTO);
        Task<bool> DeleteStudentAsync(int studentId);
    }
}
