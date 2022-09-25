using Robo.Domain.Common;
using Robo.Domain.Enums;
using Robo.Domain.Extensions;

namespace Robo.Domain.Models
{
    public class Head : BaseEntity
    {
        public Tilt Tilt { get; private set; }

        public HeadRotation HeadRotation { get; private set; }

        public Head()
        {
            Tilt = Tilt.Rest;
            HeadRotation = HeadRotation.Rest;
        }

        public void SetRotation(HeadRotation headRotation)
        {
            if (Tilt != Tilt.Down)
            {
                if (HeadRotation == headRotation || headRotation == HeadRotation.Previous() || headRotation == HeadRotation.Next())
                    HeadRotation = headRotation;
                else throw new Exception("You can't rotation the head, because it`s jump a state");
            }
            else
                throw new Exception("You can't rotation the head, because the head's tilt is Down");
        }

        public void SetTilt(Tilt tilt)
        {
            if (Tilt == tilt || tilt == Tilt.Previous() || tilt == Tilt.Next())
                Tilt = tilt;
            else throw new Exception("You can't tilt the head, because it`s jump a state");
        }
    }
}