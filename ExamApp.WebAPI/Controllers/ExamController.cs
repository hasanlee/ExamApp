using AutoMapper;
using ExamApp.EntityLayer.DTOs.Exams;
using ExamApp.EntityLayer.Entities;
using ExamApp.ServiceLayer.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IMapper _mapper;
        private readonly IValidator<Exam> _validator;
        private readonly ILogger<ExamController> _logger;

        public ExamController(ILogger<ExamController> logger, IExamService examService, IMapper mapper, IValidator<Exam> validator)
        {
            _logger = logger;
            _examService = examService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllExams()
        {
            var res = await _examService.GetAllExamsAsync();
            if (res != null)
                return Ok(res);
            return BadRequest();
        }

        [HttpPost("AddExam")]
        public async Task<IActionResult> AddExam(ExamAddDTO examDTO)
        {
            var res = await _examService.CreateExamAsync(examDTO);
            if (res)
                return Ok(new { status = true });
            return BadRequest();
        }

        [HttpPut("ModifyExam")]
        public async Task<IActionResult> UpdateExam(ExamAddDTO examDTO)
        {
            var res = await _examService.UpdateExamAsync(examDTO);
            if (res)
                return Ok(new { status = true });
            return BadRequest();
        }

        [HttpPut("DeleteExam")]
        public async Task<IActionResult> SoftDeleteExam(int examId)
        {
            var res = await _examService.DeleteExamAsync(examId);
            if (res)
                return Ok(new { status = true });
            return BadRequest();
        }
    }
}