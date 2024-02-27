using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.DAL.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        public Task<OfficeEntity> AddAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OfficeEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OfficeEntity>> GetAllAsync(string address, string phoneNumber, string isActive, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OfficeEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OfficeEntity> UpdateAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(OfficeEntity entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
