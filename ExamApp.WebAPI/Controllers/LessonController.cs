using AutoMapper;
using ExamApp.EntityLayer.DTOs.Lessons;
using ExamApp.EntityLayer.DTOs.Students;
using ExamApp.EntityLayer.Entities;
using ExamApp.ServiceLayer.Services.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        private readonly IValidator<Lesson> _validator;
        private readonly ILogger<LessonController> _logger;

        public LessonController(ILogger<LessonController> logger, ILessonService lessonService, IMapper mapper, IValidator<Lesson> validator)
        {
            _logger = logger;
            _lessonService = lessonService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllLessons()
        {
            var res = await _lessonService.GetAllLessonsAsync();
            if (res != null)
                return StatusCode(200, res);
            return StatusCode(500, "Bad request");
        }

        [HttpPost("AddLesson")]
        public async Task<IActionResult> AddLesson(LessonDTO lessonDTO)
        {
            var res = await _lessonService.CreateLessonAsync(lessonDTO);
            if (res)
                return StatusCode(201, "Created");
            return StatusCode(500, "Bad request");
        }

        [HttpPut("ModifyLesson")]
        public async Task<IActionResult> UpdateLesson(LessonDTO lessonDTO)
        {
            var res = await _lessonService.UpdateLessonAsync(lessonDTO);
            if (res)
                return StatusCode(200, "Updated");
            return StatusCode(500, "Bad request");
        }

        [HttpPut("DeleteLesson")]
        public async Task<IActionResult> SoftDeleteLesson(int lessonId)
        {
            var res = await _lessonService.DeleteLessonAsync(lessonId);
            if (res)
                return StatusCode(200, "Deleted");
            return StatusCode(500, "Bad request");
        }
    }
}
