using SmartMed.Models;

namespace SmartMed.Validators
{
    public class MedicationValidator : IValidator<Medication>
    {
        public bool Validate(Medication value)
        {
            if(value.Quantity <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
