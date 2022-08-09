namespace SmartMed.Dto
{
    public class MedicationViewModel
    {
        public Guid Id { get; set; }
        public String? Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
