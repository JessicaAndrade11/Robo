using Robo.Domain.Enums;

namespace Robo.Domain.Models
{
    public class Wrist
    {
        public Rotation Rotation { get; set; }

        public Wrist()
        {
            Rotation = Rotation.Rest;
        }
    }
}