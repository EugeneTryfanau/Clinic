using AutoMapper;
using Profiles.BLL.Interrfaces;
using Profiles.BLL.Models;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;

namespace Profiles.BLL.Services
{
    public class PatientService : GenericService<PatientEntity, Patient>, IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository, IMapper mapper) : base(patientRepository, mapper)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync(string? name, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync(name, cancellationToken);

            return _mapper.Map<IEnumerable<Patient>>(patients);
        }
    }
}
