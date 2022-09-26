using Robo.Domain.Interfaces;
using Robo.Domain.Models;

namespace Robo.Domain.Services
{
    public class RoboService : IRoboService
    {
        public RoboUnit CreateRobo()
        {
            return new RoboUnit();
        }
    }
}