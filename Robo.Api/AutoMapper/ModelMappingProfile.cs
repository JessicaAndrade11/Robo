using AutoMapper;
using Robo.Api.Models;
using Robo.Domain.Models;

namespace Robo.Api.AutoMapper
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<HeadViewModel, Head>().ReverseMap();
            CreateMap<RoboViewModel, RoboUnit>().ReverseMap();
            CreateMap<RightArmViewModel, RightArm>().ReverseMap();
            CreateMap<LeftArmViewModel, LeftArm>().ReverseMap();
            CreateMap<WristViewModel, Wrist>().ReverseMap();
            CreateMap<ElbowViewModel, Elbow>().ReverseMap();
        }
    }
}