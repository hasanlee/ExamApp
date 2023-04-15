using AutoMapper;
using ExamApp.EntityLayer.DTOs.Students;
using ExamApp.EntityLayer.Entities;

namespace ExamApp.ServiceLayer.AutoMapper.Images
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentDTO, Student>().ReverseMap();
        }
    }
}
