using AutoMapper;
using Profiles.BLL.Interrfaces;
using Profiles.BLL.Models;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;

namespace Profiles.BLL.Services
{
    public class ReceptionistService : GenericService<ReceptionistEntity, Receptionist>, IReceptionistService
    {
        private readonly IReceptionistRepository _receptionistRepository;

        public ReceptionistService(IReceptionistRepository receptionistRepository, IMapper mapper) : base(receptionistRepository, mapper)
        {
            _receptionistRepository = receptionistRepository;
        }

        public async Task<IEnumerable<Receptionist>> GetAllAsync(string? name, CancellationToken cancellationToken)
        {
            var receptionists = await _receptionistRepository.GetAllAsync(name, cancellationToken);

            return _mapper.Map<IEnumerable<Receptionist>>(receptionists);
        }
    }
}
