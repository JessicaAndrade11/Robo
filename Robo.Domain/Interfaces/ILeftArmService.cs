using Robo.Domain.Enums;
using Robo.Domain.Models;

namespace Robo.Domain.Interfaces
{
    public interface ILeftArmService
    {
        LeftArm ElbowUpdateContraction(LeftArm leftArm, Contraction contraction);

        LeftArm WristUpdateRotation(LeftArm leftArm, ArmRotation armRotation);
    }
}