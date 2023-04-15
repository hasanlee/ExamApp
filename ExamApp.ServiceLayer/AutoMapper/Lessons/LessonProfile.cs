using AutoMapper;
using ExamApp.EntityLayer.DTOs.Lessons;
using ExamApp.EntityLayer.Entities;

namespace ExamApp.ServiceLayer.AutoMapper.Brands
{
    public class LessonProfile:Profile
    {
        public LessonProfile()
        {
            CreateMap<LessonDTO, Lesson>().ReverseMap();
        }
    }
}
