using ExamApp.ServiceLayer.Services.Concretes;
using ExamApp.ServiceLayer.Services.Contracts;
using ExamApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ExamApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDashboardService dashboardService;

        public HomeController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> YearlyExamCounts()
        {
            var count = await dashboardService.GetYearlyExamCounts();
            return Json(JsonConvert.SerializeObject(count));
        }
        [HttpGet]
        public async Task<IActionResult> TotalExamCount()
        {
            var count = await dashboardService.GetTotalExamCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalStudentCount()
        {
            var count = await dashboardService.GetTotalStudentCount();
            return Json(count);
        }

        [HttpGet]
        public async Task<IActionResult> TotalLessonCount()
        {
            var count = await dashboardService.GetTotalLessonCount();
            return Json(count);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}