using Robo.Domain.Common;
using Robo.Domain.Enums;

namespace Robo.Domain.Models
{
    public abstract class Arm : BaseEntity
    {
        public Elbow Elbow { get; private set; }

        public Wrist Wrist { get; private set; }

        protected Arm()
        {
            Elbow = new Elbow();
            Wrist = new Wrist();
        }

        public virtual void MovementWrist(ArmRotation armRotation)
        {
            if (Elbow.Contraction == Contraction.StronglyContracted)
                Wrist.SetRotation(armRotation);
            else
                throw new Exception("You can't movement wrist, because the elbow is not strongly contracted");
        }
    }
}