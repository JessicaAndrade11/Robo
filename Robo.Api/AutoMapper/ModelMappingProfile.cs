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
        }
    }
}