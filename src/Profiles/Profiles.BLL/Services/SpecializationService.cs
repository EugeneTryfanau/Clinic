﻿using AutoMapper;
using Profiles.BLL.Interrfaces;
using Profiles.BLL.Models;
using Profiles.DAL.Entities;
using Profiles.DAL.Interfaces;

namespace Profiles.BLL.Services
{
    public class SpecializationService : GenericService<SpecializationEntity, Specialization>, ISpecializationService
    {
        private readonly ISpecializationRepository _specializationRepository;

        public SpecializationService(ISpecializationRepository specializationRepository, IMapper mapper) : base(specializationRepository, mapper)
        {
            _specializationRepository = specializationRepository;
        }

        public async Task<IEnumerable<Specialization>> GetAllAsync(string? specName, CancellationToken cancellationToken)
        {
            var specializations = await _specializationRepository.GetAllAsync(specName, cancellationToken);

            return _mapper.Map<IEnumerable<Specialization>>(specializations);
        }
    }
}
