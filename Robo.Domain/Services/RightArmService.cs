using Robo.Domain.Enums;
using Robo.Domain.Interfaces;
using Robo.Domain.Models;

namespace Robo.Domain.Services
{
    public class RightArmService : IRightArmService
    {
        public RightArm ElbowUpdateContraction(RightArm rightArm, Contraction contraction)
        {
            rightArm.Elbow.setContraction(contraction);
            return rightArm;
        }

        public RightArm WristUpdateRotation(RightArm rightArm, ArmRotation armRotation)
        {
            rightArm.MovementWrist(armRotation);
            return rightArm;
        }
    }
}