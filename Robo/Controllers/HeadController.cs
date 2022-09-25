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

        [HttpPut("rotation")]
        public IActionResult PutRotation([FromBody] HeadViewModel headToUpdate, HeadRotation headRotation)
        {
            var head = _mapper.Map<Head>(headToUpdate);
            var headUpdated = _headService.PutRotation(head, headRotation);
            var headViewModel = _mapper.Map<HeadViewModel>(headUpdated);
            return Ok(headViewModel);
        }

        [HttpPut("tilt")]
        public IActionResult PutTilt([FromBody] HeadViewModel headToUpdate, Tilt tilt)
        {
            var head = _mapper.Map<Head>(headToUpdate);
            var headUpdated = _headService.PutTilt(head, tilt);
            var headViewModel = _mapper.Map<HeadViewModel>(headUpdated);
            return Ok(headViewModel);
        }
    }
}