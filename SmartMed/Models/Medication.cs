namespace SmartMed.Models
{
    public class Medication : ModelBase
    {
        public Medication(Guid id, string name, int quantity, DateTime creationDate)
            :base(id)
        {
            Name = name;
            Quantity = quantity;
            CreationDate = creationDate;
        }

        public string Name { get; }
        public int Quantity { get; }
        public DateTime CreationDate { get; }
    }
}
