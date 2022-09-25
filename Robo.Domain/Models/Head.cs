﻿using Robo.Domain.Common;
using Robo.Domain.Enums;

namespace Robo.Domain.Models
{
    public class Head : BaseEntity
    {
        public Slope Slope { get; private set; }

        public Rotation Rotation { get; private set; }

        public Head()
        {
            Slope = Slope.Rest;
            Rotation = Rotation.Rest;
        }

        public void SetRotation(Rotation rotation)
        {
            if (Slope != Slope.Down)
                Rotation = rotation;
        }

        public void SetSlope(Slope slope)
        {
            Slope = slope;
        }
    }
}