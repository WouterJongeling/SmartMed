using AutoMapper;
using SmartMed.Dbo;
using SmartMed.ViewModels;
using SmartMed.Models;

namespace SmartMed
{
    public class SmartMedMapperProfile : Profile
    {
        public SmartMedMapperProfile()
        {
            CreateMap<MedicationCreateModel, Medication>()
                .ForCtorParam("id", cfg => cfg.MapFrom(src => new Guid()))
                .ForCtorParam("creationDate", cfg => cfg.MapFrom(src => new DateTime()));
            CreateMap<Medication, MedicationViewModel>();
            CreateMap<Medication, MedicationDbo>()
                .ReverseMap();
        }
    }
}
