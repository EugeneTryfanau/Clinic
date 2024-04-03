using AutoMapper;
using Profiles.BLL.Interfaces;
using Profiles.BLL.Models;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;
using StandartCRUD;
using StandartCRUD.StandartBLL;

namespace Profiles.BLL.Services
{
    public class DoctorService(IDoctorRepository doctorRepository, IMapper mapper) :
        GenericService<DoctorEntity, Doctor>(doctorRepository, mapper),
        IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository = doctorRepository;

        public async Task<IEnumerable<Doctor>> GetAllAsync(string? name, DoctorStatus? status, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAllAsync(name, status, cancellationToken);

            return _mapper.Map<IEnumerable<Doctor>>(doctors);
        }
    }
}
