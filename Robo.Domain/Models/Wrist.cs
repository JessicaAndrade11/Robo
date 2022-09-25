using Robo.Domain.Enums;
using Robo.Domain.Extensions;

namespace Robo.Domain.Models
{
    public class Wrist
    {
        public ArmRotation ArmRotation { get; private set; }

        public Wrist()
        {
            ArmRotation = ArmRotation.Rest;
        }

        public void SetRotation(ArmRotation armRotation)
        {
            if (ArmRotation == armRotation || armRotation == ArmRotation.Previous() || armRotation == ArmRotation.Next())
                ArmRotation = armRotation;
            else throw new Exception("You can't rotation the wrist, because it`s jump a state");
        }
    }
}