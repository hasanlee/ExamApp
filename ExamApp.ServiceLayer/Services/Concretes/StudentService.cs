using AutoMapper;
using ExamApp.DataAccessLayer.UnitOfWorks;
using ExamApp.EntityLayer.DTOs.Students;
using ExamApp.EntityLayer.Entities;
using ExamApp.ServiceLayer.Services.Contracts;

namespace ExamApp.ServiceLayer.Services.Concretes
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateStudentAsync(StudentDTO studentDTO)
        {
            var student = _mapper.Map<Student>(studentDTO);
            await _unitOfWork.GetRepository<Student>().AddAsync(student);
            var res = await _unitOfWork.SaveAsync();
            return res > 0;
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            var student = await _unitOfWork.GetRepository<Student>().GetByIdAsync(studentId);

            student.IsDeleted = true;
            student.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepository<Student>().Update(student);
            var res = await _unitOfWork.SaveAsync();
            return res > 0;
        }

        public async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _unitOfWork.GetRepository<Student>().GetAllAsync(d => !d.IsDeleted);
            var mappedStudents = _mapper.Map<List<StudentDTO>>(students);
            return mappedStudents;
        }

        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            var student = await _unitOfWork.GetRepository<Student>().GetByIdAsync(id);
            var mappedStudent = _mapper.Map<StudentDTO>(student);
            return mappedStudent;
        }

        public async Task<bool> UpdateStudentAsync(StudentDTO studentDTO)
        {
            var student = await _unitOfWork.GetRepository<Student>().GetAsync(x => !x.IsDeleted && x.Id == studentDTO.Id);

            _mapper.Map(studentDTO, student);
            student.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepository<Student>().Update(student);
            var res = await _unitOfWork.SaveAsync();

            return res > 0;
        }
    }
}
