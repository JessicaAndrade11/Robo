using Robo.Domain.Enums;
using Robo.Domain.Models;

namespace Robo.Domain.Interfaces
{
    public interface IHeadService
    {
        Head CreateHead();
        Head PutRotation(Head head, HeadRotation headRotation);
        Head PutSlope(Head head, Slope slope);
    }
}