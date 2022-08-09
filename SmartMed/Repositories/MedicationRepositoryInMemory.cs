using AutoMapper;
using SmartMed.Dbo;
using SmartMed.Models;

namespace SmartMed.Repositories
{
    public class MedicationRepositoryInMemory : InMemoryRepository<Medication, MedicationDbo>
    {
        public MedicationRepositoryInMemory(IMapper mapper) : base(mapper)
        {
        }
    }
}
