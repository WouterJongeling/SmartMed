using AutoMapper;
using SmartMed.Models;
using SmartMed.Repositories;

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
        }
    }
}
