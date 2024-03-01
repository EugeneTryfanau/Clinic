using AutoMapper;
using Clinic.API.Mapper;
using Clinic.BLL.Models;
using Clinic.BLL.Services;
using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using Clinic.UnitTests.TestData.Offices;
using NSubstitute;
using Shouldly;
using System.Collections.Generic;

namespace Clinic.UnitTests.ServiceTests
{
    public class OfficeServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IOfficeRepository _officeRepository;
        private readonly OfficeService _officeService;

        public OfficeServiceTests()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

            _officeRepository = Substitute.For<IOfficeRepository>();
            _officeService = new OfficeService(_officeRepository, _mapper);
        }

        [Fact]
        public async Task GetAllAsync_ByIsActive_ReturnCollectionOfOffices()
        {
            _officeRepository.GetAllAsync(null, null, OfficeStatus.Active, Arg.Any<CancellationToken>()).Returns(
                    _mapper.Map<IEnumerable<OfficeEntity>>(TestOfficeModels.SortOffices(null, null, OfficeStatus.Active, new CancellationToken()))
                );
            
            var result = await _officeService.GetAllAsync(null, null, OfficeStatus.Active, new CancellationToken());
            
            await _officeRepository.Received(1).GetAllAsync(null, null, OfficeStatus.Active, Arg.Any<CancellationToken>());
            result.Count().ShouldBeEquivalentTo(1);
        }

        //ыыыыынеыыыыыыыыыыыыыыыыыыыыыыработаетыыыыыыыыыыыыыы
        //[Fact]
        //public async Task CreateOfficeAsync_ReturnCreatedOffice()
        //{
        //    var kek = TestOfficeModels.Office;
        //    _officeRepository.AddAsync(kek, Arg.Any<CancellationToken>()).Returns(kek);
        //    var sendObject = _mapper.Map<Office>(kek);

        //    var result = await _officeService.CreateAsync(sendObject, CancellationToken.None);

        //    result.ShouldBeEquivalentTo(sendObject);
        //}
    }
}
