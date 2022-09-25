using Robo.Domain.Enums;
using Robo.Domain.Extensions;

namespace Robo.Domain.Models
{
    public class Elbow
    {
        public Contraction Contraction { get; private set; }

        public Elbow()
        {
            Contraction = Contraction.Rest;
        }

        public void setContraction(Contraction contraction)
        {
            if (Contraction == contraction || contraction == Contraction.Previous() || contraction == Contraction.Next())
                Contraction = contraction;
            else throw new Exception("You can't contract the elbow, because it`s jump a state");
        }
    }
}