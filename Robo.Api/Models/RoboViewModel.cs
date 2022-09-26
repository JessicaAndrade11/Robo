namespace Robo.Api.Models
{
    public class RoboViewModel
    {
        public Guid Id { get; set; }
        public HeadViewModel Head { get; set; }
        public RightArmViewModel RightArm { get; set; }
        public LeftArmViewModel LeftArm { get; set; }
    }
}