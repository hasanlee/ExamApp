using ExamApp.DataAccessLayer.UnitOfWorks;
using ExamApp.EntityLayer.Entities;
using ExamApp.ServiceLayer.Services.Contracts;

namespace ExamApp.ServiceLayer.Services.Concretes
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> GetTotalExamCount()
        {
            var examCount = await unitOfWork.GetRepository<Exam>().CountAsync();
            return examCount;
        }

        public async Task<int> GetTotalLessonCount()
        {
            var lessonCount = await unitOfWork.GetRepository<Lesson>().CountAsync();
            return lessonCount;
        }

        public async Task<int> GetTotalStudentCount()
        {
            var studentCount = await unitOfWork.GetRepository<Student>().CountAsync();
            return studentCount;
        }

        public async Task<List<int>> GetYearlyExamCounts()
        {
            var exams = await unitOfWork.GetRepository<Exam>().GetAllAsync(x => !x.IsDeleted);

            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, 1, 1);

            List<int> datas = new();

            for (int i = 1; i <= 12; i++)
            {
                var startedDate = new DateTime(startDate.Year, i, 1);
                var endedDate = startedDate.AddMonths(1);
                var data = exams.Where(x => x.ExamDate >= startedDate && x.ExamDate < endedDate).Count();
                datas.Add(data);
            }

            return datas;
        }
    }
}
