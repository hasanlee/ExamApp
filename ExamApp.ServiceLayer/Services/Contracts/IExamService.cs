using ExamApp.EntityLayer.DTOs.Exams;

namespace ExamApp.ServiceLayer.Services.Contracts
{
    public interface IExamService
    {
        Task<List<ExamDTO>> GetAllExamsAsync();
        Task<ExamDTO> GetExamByIdAsync(int id);
        Task<bool> CreateExamAsync(ExamAddDTO examDTO);
        Task<bool> UpdateExamAsync(ExamAddDTO examDTO);
        Task<bool> DeleteExamAsync(int examId);
    }
}
