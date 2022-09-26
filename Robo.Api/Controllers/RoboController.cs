using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Robo.Api.Models;
using Robo.Domain.Interfaces;

namespace Robo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoboController : ControllerBase
    {
        private readonly IRoboService _roboService;
        private readonly IMapper _mapper;

        public RoboController(
            IRoboService roboService,
            IMapper mapper)
        {
            _roboService = roboService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateRobo()
        {
            var roboNew = _roboService.CreateRobo();
            var roboViewModel = _mapper.Map<RoboViewModel>(roboNew);

            return Ok(roboViewModel);
        }
    }
}