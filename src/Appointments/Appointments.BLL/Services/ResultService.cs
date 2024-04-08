using Appointments.BLL.Interfaces;
using Appointments.BLL.Models;
using Appointments.DAL.Entities;
using Appointments.DAL.Interfaces;
using AutoMapper;
using StandartCRUD.StandartBLL;

namespace Appointments.BLL.Services
{
    public class ResultService(IResultRepository resultRepository, IMapper mapper) :
        GenericService<ResultEntity, Result>(resultRepository, mapper),
        IResultService
    {
        private readonly IResultRepository _resultRepository = resultRepository;

        public async Task<IEnumerable<Result>> GetAll(Guid? appountmentId, CancellationToken cancellationToken)
        {
            var results = await _resultRepository.GetAll(appountmentId, cancellationToken);

            return _mapper.Map<IEnumerable<Result>>(results);
        }
    }
}
