using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.ServiceLayer.Services.Contracts
{
    public interface IDashboardService
    {
        Task<List<int>> GetYearlyExamCounts();
        Task<int> GetTotalStudentCount();
        Task<int> GetTotalExamCount();
        Task<int> GetTotalLessonCount();
    }
}
