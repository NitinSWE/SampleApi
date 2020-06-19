using AutoMapper;
using sampleapi.Dtos;
using sampleapi.Models;

namespace sampleapi.Profiles
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            //Source => Target
            CreateMap<Test,TestReadDto>();
            CreateMap<TestCreateDto,Test>();
            CreateMap<TestUpdateDto,Test>();
            CreateMap<Test,TestUpdateDto>();
        }
    }
}