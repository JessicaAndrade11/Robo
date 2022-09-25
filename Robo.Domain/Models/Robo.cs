using Robo.Domain.Common;

namespace Robo.Domain.Models
{
    public class Robo : BaseEntity
    {
        public Robo(Head head, RightArm rightArm, LeftArm leftArm)
        {
            Head = head;
            RightArm = rightArm;
            LeftArm = leftArm;
        }

        public Head Head { get; private set; }
        public RightArm RightArm { get; private set; }
        public LeftArm LeftArm { get; private set; }
    }
}