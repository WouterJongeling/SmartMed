using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartMed.ViewModels;
using SmartMed.Models;
using SmartMed.Repositories;
using SmartMed.Validators;

namespace SmartMed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationController
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Medication> _repository;
        private readonly IValidator<Medication> _validator;

        public MedicationController(IMapper mapper, IRepository<Medication> repository, IValidator<Medication> validator)
        {
            _mapper = mapper;
            _repository = repository;
            _validator = validator;
        }

        [HttpGet]
        public IEnumerable<MedicationViewModel> GetAllMedications()
        {
            return _repository.GetAll()
                .Select(entity => _mapper.Map<MedicationViewModel>(entity));
        }

        [HttpPost]
        public MedicationViewModel CreateMedication(MedicationCreateModel createModel)
        {
            Medication entity = _mapper.Map<Medication>(createModel);
            if(!_validator.Validate(entity))
            {
                throw new ValidationException();
            }
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