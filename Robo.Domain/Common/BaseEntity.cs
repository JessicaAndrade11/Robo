namespace Robo.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}