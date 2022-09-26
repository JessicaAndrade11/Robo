using Robo.Domain.Enums;
using Robo.Domain.Interfaces;
using Robo.Domain.Models;

namespace Robo.Domain.Services
{
    public class HeadService : IHeadService
    {
        public Head PutRotation(Head head, HeadRotation headrotation)
        {
            head.SetRotation(headrotation);
            return head;
        }

        public Head PutTilt(Head head, Tilt tilt)
        {
            head.SetTilt(tilt);
            return head;
        }
    }
}