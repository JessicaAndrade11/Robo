﻿using Robo.Domain.Enums;
using Robo.Domain.Interfaces;
using Robo.Domain.Models;

namespace Robo.Domain.Services
{
    public class HeadService : IHeadService
    {
        public Head CreateHead()
        {
           return new Head();
        }

        public Head PutRotation(Head head, HeadRotation headrotation)
        {
            head.SetRotation(headrotation);
            return head;
        }

        public Head PutSlope(Head head, Slope slope)
        {
            head.SetSlope(slope);
            return head;
        }
    }
}