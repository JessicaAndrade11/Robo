namespace Robo.Api.Models
{
    public class RightArmViewModel
    {
        public Guid Id { get; set; }
        public ElbowViewModel Elbow { get; set; }
        public WristViewModel Wrist { get; set; }
    }
}