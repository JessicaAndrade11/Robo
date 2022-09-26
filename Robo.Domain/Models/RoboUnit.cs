using Robo.Domain.Common;

namespace Robo.Domain.Models
{
    public class RoboUnit : BaseEntity
    {
        public RoboUnit()
        {
            Head = new Head();
            RightArm = new RightArm();
            LeftArm = new LeftArm();
        }

        public Head Head { get; private set; }
        public RightArm RightArm { get; private set; }
        public LeftArm LeftArm { get; private set; }
    }
}