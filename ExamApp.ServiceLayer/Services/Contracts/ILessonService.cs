using ExamApp.EntityLayer.DTOs.Lessons;

namespace ExamApp.ServiceLayer.Services.Contracts
{
    public interface ILessonService
    {
        Task<List<LessonDTO>> GetAllLessonsAsync();
        Task<LessonDTO> GetLessonByIdAsync(int id);
        Task<bool> CreateLessonAsync(LessonDTO lessonDTO);
        Task<bool> UpdateLessonAsync(LessonDTO lessonDTO);
        Task<bool> DeleteLessonAsync(int lessonId);
    }
}
