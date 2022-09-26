namespace Robo.Api.Models
{
    public class LeftArmViewModel
    {
        public Guid Id { get; set; }
        public ElbowViewModel Elbow { get; set; }
        public WristViewModel Wrist { get; set; }
    }
}