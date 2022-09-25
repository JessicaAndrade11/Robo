using Robo.Domain.Enums;

namespace Robo.Api.Models
{
    public class HeadViewModel
    {
        public Guid Id { get; set; }
        public Slope Slope { get; set; }
        public HeadRotation HeadRotation { get; set; }
    }
}