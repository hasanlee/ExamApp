using AutoMapper;
using ExamApp.DataAccessLayer.UnitOfWorks;
using ExamApp.EntityLayer.DTOs.Exams;
using ExamApp.EntityLayer.Entities;
using ExamApp.ServiceLayer.Services.Contracts;

namespace ExamApp.ServiceLayer.Services.Concretes
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateExamAsync(ExamAddDTO examDTO)
        {
            var exam = _mapper.Map<Exam>(examDTO);
            await _unitOfWork.GetRepository<Exam>().AddAsync(exam);
            var res = await _unitOfWork.SaveAsync();
            return res > 0;
        }

        public async Task<bool> DeleteExamAsync(int examId)
        {
            var exam = await _unitOfWork.GetRepository<Exam>().GetByIdAsync(examId);

            exam.IsDeleted = true;
            exam.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepository<Exam>().Update(exam);
            var res = await _unitOfWork.SaveAsync();
            return res > 0;
        }

        public async Task<List<ExamDTO>> GetAllExamsAsync()
        {
            var exams = await _unitOfWork.GetRepository<Exam>().GetAllAsync(d => !d.IsDeleted,s=>s.Student,l=>l.Lesson);
            var mappedExams = _mapper.Map<List<ExamDTO>>(exams);
            return mappedExams;
        }

        public async Task<ExamDTO> GetExamByIdAsync(int id)
        {
            var exam = await _unitOfWork.GetRepository<Exam>().GetByIdAsync(id);
            var mappedExam = _mapper.Map<ExamDTO>(exam);
            return mappedExam;
        }

        public async Task<bool> UpdateExamAsync(ExamAddDTO examDTO)
        {
            var exam = await _unitOfWork.GetRepository<Exam>().GetAsync(x => !x.IsDeleted && x.Id == examDTO.Id);

            _mapper.Map(examDTO, exam);
            exam.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepository<Exam>().Update(exam);
            var res = await _unitOfWork.SaveAsync();

            return res > 0;
        }
    }
}
