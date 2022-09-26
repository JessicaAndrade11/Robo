using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Robo.Api.Models;
using Robo.Domain.Enums;
using Robo.Domain.Interfaces;
using Robo.Domain.Models;

namespace Robo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPut("elbow/contraction/{contraction}")]
        public IActionResult PutElbowContraction([FromBody] LeftArmViewModel leftArmToUpdate, Contraction contraction)
        {
            try
            {
                var leftArm = _mapper.Map<LeftArm>(leftArmToUpdate);
                var leftArmUpdated = _leftArmService.ElbowUpdateContraction(leftArm, contraction);
                var leftArmViewModel = _mapper.Map<LeftArmViewModel>(leftArmUpdated);
                return Ok(leftArmViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("wrist/rotation/{armRotation}")]
        public IActionResult PutWristRotation([FromBody] LeftArmViewModel leftArmToUpdate, ArmRotation armRotation)
        {
            try
            {
                var leftArm = _mapper.Map<LeftArm>(leftArmToUpdate);
                var leftArmUpdated = _leftArmService.WristUpdateRotation(leftArm, armRotation);
                var leftArmViewModel = _mapper.Map<LeftArmViewModel>(leftArmUpdated);
                return Ok(leftArmViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}