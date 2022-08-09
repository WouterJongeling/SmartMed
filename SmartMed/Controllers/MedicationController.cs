using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartMed.Dto;
using SmartMed.Models;
using SmartMed.Repositories;

namespace SmartMed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationController
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Medication> _repository;

        public MedicationController(IMapper mapper, IRepository<Medication> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<MedicationViewModel> GetAllMedications()
        {
            return _repository.GetAll()
                .Select(entity => _mapper.Map<MedicationViewModel>(entity));
        }

        [HttpPost]
        public MedicationViewModel CreateMedication(MedicationCreateModel medication)
        {
            Medication entity = _mapper.Map<Medication>(medication);
            Medication result = _repository.Add(entity);
            MedicationViewModel viewModel = _mapper.Map<MedicationViewModel>(result);
            return viewModel;
        }

        [HttpDelete]
        public void Delete(Guid medicationId)
        {
            _repository.Delete(medicationId);
        }
    }
}