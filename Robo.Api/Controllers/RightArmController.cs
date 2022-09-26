using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Robo.Domain.Interfaces;

namespace Robo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RightArmController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRightArmService _rightArmService;

        public RightArmController(
            IMapper mapper,
            IRightArmService rightArmService)
        {
            _mapper = mapper;
            _rightArmService = rightArmService;
        }
    }
}