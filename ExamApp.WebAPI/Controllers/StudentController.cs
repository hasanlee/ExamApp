using AutoMapper;
using ExamApp.EntityLayer.DTOs.Students;
using ExamApp.EntityLayer.Entities;
using ExamApp.ServiceLayer.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IValidator<Student> _validator;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService, IMapper mapper, IValidator<Student> validator)
        {
            _logger = logger;
            _studentService = studentService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStudents()
        {
            var res = await _studentService.GetAllStudentsAsync();
            if (res != null)
                return StatusCode(200, res);
            return StatusCode(500, "Bad request");
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(StudentDTO studentDTO)
        {
            var res = await _studentService.CreateStudentAsync(studentDTO);
            if (res)
                return StatusCode(201, "Created");
            return StatusCode(500, "Bad request");
        }

        [HttpPut("ModifyStudent")]
        public async Task<IActionResult> UpdateStudent(StudentDTO studentDTO)
        {
            var res = await _studentService.UpdateStudentAsync(studentDTO);
            if (res)
                return StatusCode(200, "Updated");
            return StatusCode(500, "Bad request");
        }

        [HttpPut("DeleteStudent")]
        public async Task<IActionResult> SoftDeleteStudent(int studentId)
        {
            var res = await _studentService.DeleteStudentAsync(studentId);
            if (res)
                return StatusCode(200, "Deleted");
            return StatusCode(500, "Bad request");
        }
    }
}
