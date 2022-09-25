using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Robo.Domain.Interfaces;

namespace Robo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeftArmController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILeftArmService _leftArmService;

        public LeftArmController(
            IMapper mapper,
            ILeftArmService leftArmService)
        {
            _mapper = mapper;
            _leftArmService = leftArmService;
        }
    }
}