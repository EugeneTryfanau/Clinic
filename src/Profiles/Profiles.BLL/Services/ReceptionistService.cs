using AutoMapper;
using Profiles.BLL.Interrfaces;
using Profiles.BLL.Models;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;
using StandartCRUD.StandartBLL;

namespace Profiles.BLL.Services
{
    public class ReceptionistService(IReceptionistRepository receptionistRepository, IMapper mapper) : 
        GenericService<ReceptionistEntity, Receptionist>(receptionistRepository, mapper), 
        IReceptionistService
    {
        private readonly IReceptionistRepository _receptionistRepository = receptionistRepository;

        public async Task<IEnumerable<Receptionist>> GetAllAsync(string? name, CancellationToken cancellationToken)
        {
            var receptionists = await _receptionistRepository.GetAllAsync(name, cancellationToken);

            return _mapper.Map<IEnumerable<Receptionist>>(receptionists);
        }
    }
}
