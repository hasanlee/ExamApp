using AutoMapper;
using ExamApp.EntityLayer.DTOs.Exams;
using ExamApp.EntityLayer.Entities;

namespace ExamApp.ServiceLayer.AutoMapper.Adverts
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<ExamDTO,Exam>().ReverseMap();
            CreateMap<ExamAddDTO,Exam>().ReverseMap();
            CreateMap<ExamAddDTO,ExamDTO>().ReverseMap();
        }
    }
}
