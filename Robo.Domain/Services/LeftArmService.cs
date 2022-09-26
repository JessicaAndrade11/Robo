using Robo.Domain.Enums;
using Robo.Domain.Interfaces;
using Robo.Domain.Models;

namespace Robo.Domain.Services
{
    public class LeftArmService : ILeftArmService
    {
        public LeftArm ElbowUpdateContraction(LeftArm leftArm, Contraction contraction)
        {
            leftArm.Elbow.setContraction(contraction);
            return leftArm;
        }

        public LeftArm WristUpdateRotation(LeftArm leftArm, ArmRotation armRotation)
        {
            leftArm.MovementWrist(armRotation);
            return leftArm;
        }
    }
}