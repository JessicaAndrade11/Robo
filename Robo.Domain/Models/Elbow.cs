using Robo.Domain.Enums;

namespace Robo.Domain.Models
{
    public class Elbow
    {
        public Contracted Contracted { get; private set; }

        public Elbow()
        {
            Contracted = Contracted.Rest;    
        }

        public void setContracted(Contracted contracted)
        {
            Contracted = contracted;
        }
    }
}