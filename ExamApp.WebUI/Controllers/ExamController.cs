using AutoMapper;
using ExamApp.EntityLayer.DTOs.Exams;
using ExamApp.EntityLayer.DTOs.Students;
using ExamApp.EntityLayer.Entities;
using ExamApp.ServiceLayer.Extensions;
using ExamApp.ServiceLayer.Services.Contracts;
using ExamApp.WebUI.ResponseMessages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ExamApp.WebUI.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService examService;
        private readonly IStudentService studentService;
        private readonly ILessonService lessonService;
        private readonly IMapper mapper;
        private readonly IValidator<Exam> validator;
        private readonly IToastNotification toastNotification;

        public ExamController(IExamService examService, IStudentService studentService, ILessonService lessonService, IMapper mapper, IValidator<Exam> validator, IToastNotification toastNotification)
        {
            this.examService = examService;
            this.studentService = studentService;
            this.lessonService = lessonService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var exams = await examService.GetAllExamsAsync();
            return View(exams);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var students = await studentService.GetAllStudentsAsync();
            var lessons = await lessonService.GetAllLessonsAsync();
            return View(new ExamAddDTO { Lessons = lessons, Students = students });
        }
        [HttpPost]
        public async Task<IActionResult> Add(ExamAddDTO examDTO)
        {
            var map = mapper.Map<Exam>(examDTO);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await examService.CreateExamAsync(examDTO);
                toastNotification.AddSuccessToastMessage(Messages.Add("Exam"));
                return RedirectToAction("Index", "Exam");
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int examId)
        {
            var exam = await examService.GetExamByIdAsync(examId);
            var students = await studentService.GetAllStudentsAsync();
            var lessons = await lessonService.GetAllLessonsAsync();
            var examUpdate = mapper.Map<ExamAddDTO>(exam);
            examUpdate.Students = students;
            examUpdate.Lessons = lessons;
            return View(examUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ExamAddDTO examDTO)
        {

            var map = mapper.Map<Exam>(examDTO);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                _ = await examService.UpdateExamAsync(examDTO);
                toastNotification.AddSuccessToastMessage(Messages.Update(examDTO.Id + " exam"));
                return RedirectToAction("Index", "Exam");

            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            return View(examDTO);
        }
        public async Task<IActionResult> Delete(int examId)
        {
            _ = await examService.DeleteExamAsync(examId);
            toastNotification.AddSuccessToastMessage(Messages.Delete(examId.ToString()));
            return RedirectToAction("Index", "Exam");
        }
    }
}
