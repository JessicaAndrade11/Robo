using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Robo.Api.Models;
using Robo.Domain.Enums;
using Robo.Domain.Interfaces;
using Robo.Domain.Models;

namespace Robo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeadController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHeadService _headService;

        public HeadController(
            IHeadService headService,
            IMapper mapper)
        {
            _headService = headService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostCreateHead()
        {
            var headNew = _headService.CreateHead();
            var headViewModel = _mapper.Map<HeadViewModel>(headNew);
            return Ok(headViewModel);
        }

        [HttpPut]
        public IActionResult PutRotation(Head head, Rotation rotation)
        {
            var headUpdated = _headService.PutRotation(head, rotation);
            var headViewModel = _mapper.Map<HeadViewModel>(headUpdated);
            return Ok(headViewModel);
        }

        [HttpPut]
        public IActionResult PutSlope(Head head, Slope slope)
        {
            var headUpdated = _headService.PutSlope(head, slope);
            var headViewModel = _mapper.Map<HeadViewModel>(headUpdated);
            return Ok(headViewModel);
        }
    }
}