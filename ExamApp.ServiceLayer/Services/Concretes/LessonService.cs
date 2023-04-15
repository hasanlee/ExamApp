using AutoMapper;
using ExamApp.DataAccessLayer.UnitOfWorks;
using ExamApp.EntityLayer.DTOs.Lessons;
using ExamApp.EntityLayer.Entities;
using ExamApp.ServiceLayer.Services.Contracts;

namespace ExamApp.ServiceLayer.Services.Concretes
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateLessonAsync(LessonDTO lessonDTO)
        {
            var lesson = _mapper.Map<Lesson>(lessonDTO);
            await _unitOfWork.GetRepository<Lesson>().AddAsync(lesson);
            var res = await _unitOfWork.SaveAsync();
            return res > 0;
        }

        public async Task<bool> DeleteLessonAsync(int lessonId)
        {
            var lesson = await _unitOfWork.GetRepository<Lesson>().GetByIdAsync(lessonId);

            lesson.IsDeleted = true;
            lesson.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepository<Lesson>().Update(lesson);
            var res = await _unitOfWork.SaveAsync();
            return res > 0;
        }

        public async Task<List<LessonDTO>> GetAllLessonsAsync()
        {
            var lessons = await _unitOfWork.GetRepository<Lesson>().GetAllAsync(d => !d.IsDeleted);
            var mappedLessons = _mapper.Map<List<LessonDTO>>(lessons);
            return mappedLessons;
        }

        public async Task<LessonDTO> GetLessonByIdAsync(int id)
        {
            var lesson = await _unitOfWork.GetRepository<Lesson>().GetByIdAsync(id);
            var mappedLesson = _mapper.Map<LessonDTO>(lesson);
            return mappedLesson;
        }

        public async Task<bool> UpdateLessonAsync(LessonDTO lessonDTO)
        {
            var lesson = await _unitOfWork.GetRepository<Lesson>().GetAsync(x => !x.IsDeleted && x.Id == lessonDTO.Id);

            _mapper.Map(lessonDTO, lesson);
            lesson.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepository<Lesson>().Update(lesson);
            var res = await _unitOfWork.SaveAsync();

            return res > 0;
        }
    }
}
