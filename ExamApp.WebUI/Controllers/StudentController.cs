using AutoMapper;
using ExamApp.EntityLayer.DTOs.Students;
using ExamApp.EntityLayer.Entities;
using ExamApp.ServiceLayer.Extensions;
using ExamApp.ServiceLayer.Services.Contracts;
using ExamApp.WebUI.ResponseMessages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NToastNotify;

namespace ExamApp.WebUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        private readonly IValidator<Student> validator;
        private readonly IToastNotification toastNotification;

        public StudentController(IStudentService studentService, IMapper mapper, IValidator<Student> validator, IToastNotification toastNotification)
        {
            this.studentService = studentService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var students = await studentService.GetAllStudentsAsync();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(StudentDTO studentDTO)
        {
            try
            {
                var map = mapper.Map<Student>(studentDTO);
                var result = await validator.ValidateAsync(map);

                if (result.IsValid)
                {
                    await studentService.CreateStudentAsync(studentDTO);
                    toastNotification.AddSuccessToastMessage(Messages.Add(studentDTO.FullName));
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    result.AddToModelState(this.ModelState);
                }
            }
            catch (Exception ex)
            when (ex.InnerException is SqlException sqlException && (sqlException.Number == 2601))
            {
                toastNotification.AddErrorToastMessage("Student Number already exist!");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int studentId)
        {
            var student = await studentService.GetStudentByIdAsync(studentId);
            var studentUpdate = mapper.Map<StudentDTO>(student);
            return View(studentUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(StudentDTO studentDTO)
        {

            var map = mapper.Map<Student>(studentDTO);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                _ = await studentService.UpdateStudentAsync(studentDTO);
                toastNotification.AddSuccessToastMessage(Messages.Update(studentDTO.FullName));
                return RedirectToAction("Index", "Student");

            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            return View(studentDTO);
        }
        public async Task<IActionResult> Delete(int studentId)
        {
            _ = await studentService.DeleteStudentAsync(studentId);
            toastNotification.AddSuccessToastMessage(Messages.Add(studentId.ToString()));
            return RedirectToAction("Index", "Student");
        }
    }
}
