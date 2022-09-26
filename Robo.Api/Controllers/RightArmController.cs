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

        [HttpPut("elbow/contraction/{contraction}")]
        public IActionResult PutElbowContraction([FromBody] RightArmViewModel rightArmToUpdate, Contraction contraction)
        {
            try
            {
                var rightArm = _mapper.Map<RightArm>(rightArmToUpdate);
                var rightArmUpdated = _rightArmService.ElbowUpdateContraction(rightArm, contraction);
                var rightArmViewModel = _mapper.Map<RightArmViewModel>(rightArmUpdated);
                return Ok(rightArmViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("wrist/rotation/{armRotation}")]
        public IActionResult PutWristRotation([FromBody] RightArmViewModel rightArmToUpdate, ArmRotation armRotation)
        {
            try
            {
                var rightArm = _mapper.Map<RightArm>(rightArmToUpdate);
                var rightArmUpdated = _rightArmService.WristUpdateRotation(rightArm, armRotation);
                var rightArmViewModel = _mapper.Map<RightArmViewModel>(rightArmUpdated);
                return Ok(rightArmViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}