using Robo.Domain.Enums;
using Robo.Domain.Models;

namespace Robo.Domain.Interfaces
{
    public interface IRightArmService
    {
        RightArm ElbowUpdateContraction(RightArm rightArm, Contraction contraction);

        RightArm WristUpdateRotation(RightArm rightArm, ArmRotation armRotation);
    }
}