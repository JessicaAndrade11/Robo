using Robo.Domain.Enums;

namespace Robo.Domain.Models
{
    public class RightArm : Arm
    {
        public override void MovementWrist(ArmRotation armRotation)
        {
            if (Elbow.Contraction == Contraction.StronglyContracted)
                Wrist.SetRotation(armRotation);
            else
                throw new Exception("You can't movement the right wrist, because the right elbow is not strongly contracted");
        }
    }
}