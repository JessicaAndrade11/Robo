using Robo.Domain.Enums;

namespace Robo.Domain.Models
{
    public class Wrist
    {
        public Rotation Rotation { get; private set; }

        public Wrist()
        {
            Rotation = Rotation.Rest;
        }

        public void SetRotation(Rotation rotation)
        {
            Rotation = rotation;
        }
    }
}