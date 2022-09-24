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

        protected void MovementWrist(Rotation rotation)
        {
            if(Elbow.Contracted == Contracted.StronglyContracted)
            {
                Wrist.Rotation = rotation;
            }
        }
    }
}