using AutoMapper;
using Profiles.BLL.Interrfaces;
using Profiles.BLL.Models;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;

namespace Profiles.BLL.Services
{
    public class DoctorService : GenericService<DoctorEntity, Doctor>, IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper) : base(doctorRepository, mapper)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync(string? name, DoctorStatus? status, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAllAsync(name, status, cancellationToken);

            return _mapper.Map<IEnumerable<Doctor>>(doctors);
        }
    }
}
