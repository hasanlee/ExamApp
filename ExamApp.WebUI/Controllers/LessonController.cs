using AutoMapper;
using ExamApp.EntityLayer.DTOs.Lessons;
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
    public class LessonController : Controller
    {
        private readonly ILessonService lessonService;
        private readonly IMapper mapper;
        private readonly IValidator<Lesson> validator;
        private readonly IToastNotification toastNotification;

        public LessonController(ILessonService lessonService, IMapper mapper, IValidator<Lesson> validator, IToastNotification toastNotification)
        {
            this.lessonService = lessonService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var lessons = await lessonService.GetAllLessonsAsync();
            return View(lessons);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(LessonDTO lessonDTO)
        {
            try
            {
                var map = mapper.Map<Lesson>(lessonDTO);
                var result = await validator.ValidateAsync(map);

                if (result.IsValid)
                {
                    await lessonService.CreateLessonAsync(lessonDTO);
                    toastNotification.AddSuccessToastMessage(Messages.Add(lessonDTO.Name));
                    return RedirectToAction("Index", "Lesson");
                }
                else
                {
                    result.AddToModelState(this.ModelState);
                }
            }
            catch (Exception ex)
            when (ex.InnerException is SqlException sqlException && (sqlException.Number == 2601))
            {
                toastNotification.AddErrorToastMessage("Lesson Number already exist!");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int lessonId)
        {
            var lesson = await lessonService.GetLessonByIdAsync(lessonId);
            var lessonUpdate = mapper.Map<LessonDTO>(lesson);
            return View(lessonUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(LessonDTO lessonDTO)
        {

            var map = mapper.Map<Lesson>(lessonDTO);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                _ = await lessonService.UpdateLessonAsync(lessonDTO);
                toastNotification.AddSuccessToastMessage(Messages.Update(lessonDTO.Name));
                return RedirectToAction("Index", "Lesson");

            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            return View(lessonDTO);
        }
        public async Task<IActionResult> Delete(int lessonId)
        {
            _ = await lessonService.DeleteLessonAsync(lessonId);
            toastNotification.AddSuccessToastMessage(Messages.Delete(lessonId.ToString()));
            return RedirectToAction("Index", "Lesson");
        }
    }
}
