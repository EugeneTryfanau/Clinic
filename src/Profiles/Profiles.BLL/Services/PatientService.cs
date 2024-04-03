using AutoMapper;
using Profiles.BLL.Interfaces;
using Profiles.BLL.Models;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;
using StandartCRUD.StandartBLL;

namespace Profiles.BLL.Services
{
    public class PatientService(IPatientRepository patientRepository, IMapper mapper) :
        GenericService<PatientEntity, Patient>(patientRepository, mapper),
        IPatientService
    {
        private readonly IPatientRepository _patientRepository = patientRepository;

        public async Task<IEnumerable<Patient>> GetAllAsync(string? name, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync(name, cancellationToken);

            return _mapper.Map<IEnumerable<Patient>>(patients);
        }
    }
}
