using Robo.Domain.Common;
using Robo.Domain.Enums;
using Robo.Domain.Extensions;

namespace Robo.Domain.Models
{
    public class Head : BaseEntity
    {
        public Slope Slope { get; private set; }

        public HeadRotation HeadRotation { get; private set; }

        public Head()
        {
            Slope = Slope.Rest;
            HeadRotation = HeadRotation.Rest;
        }

        public void SetRotation(HeadRotation headRotation)
        {
            if (Slope != Slope.Down)
            {
                if (HeadRotation == headRotation || headRotation == HeadRotation.Previous() || headRotation == HeadRotation.Next())
                    HeadRotation = headRotation;
                else throw new Exception("You can't rotation the head, because it`s jump a state");
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