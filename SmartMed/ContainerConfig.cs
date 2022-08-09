using AutoMapper;
using SmartMed.ViewModels;
using SmartMed.Models;
using SmartMed.Repositories;
using SmartMed.Validators;

namespace SmartMed
{
    public static class ContainerConfig
    {
        public static void ConfigureContainer(IServiceCollection services)
        { 
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new SmartMedMapperProfile())).CreateMapper();
            services.AddSingleton(mapper);

            // Repositories
            services.AddSingleton<IRepository<Medication>, MedicationRepositoryInMemory>();

            // Validators
            services.AddTransient<IValidator<Medication>, MedicationValidator>();
        }
    }
}
