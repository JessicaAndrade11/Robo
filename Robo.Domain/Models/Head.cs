using Robo.Domain.Common;
using Robo.Domain.Enums;
using Robo.Domain.Extensions;

namespace Robo.Domain.Models
{
    public class Head : BaseEntity
    {
        public Slope Slope { get; private set; }

        public Rotation Rotation { get; private set; }

        public Head()
        {
            Slope = Slope.Rest;
            Rotation = Rotation.Rest;
        }

        public void SetRotation(Rotation rotation)
        {
            if (Slope != Slope.Down)
            {
                if (Rotation == rotation)
                    return;

                if (rotation == Rotation.Previous() || rotation == Rotation.Next())
                    Rotation = rotation;
            }
            else
                throw new Exception("You can't rotation the head, because the head's slope is Down");
        }

        public void SetSlope(Slope slope)
        {
            Slope = slope;
        }
    }
}