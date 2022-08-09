namespace SmartMed.Models
{
    public abstract class ModelBase
    {
        public Guid Id { get; }

        protected ModelBase(Guid id)
        {
            Id = id;
        }
    }
}
