using AutoMapper;
using Clinic.API.Mapper;
using Clinic.BLL.Models;
using Clinic.BLL.Services;
using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using Clinic.UnitTests.TestData.Offices;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Shouldly;

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
        public async Task GetByIdAsync_ValidId_ReturnOffice()
        {
            //Arrange
            var id = new Guid();
            var office = TestOfficeModels.Office;

            _officeRepository.GetByIdAsync(id, default).Returns(office);

            //Act
            var result = await _officeService.GetByIdAsync(id, default);

            //Assert
            result.ShouldNotBeNull();
            result.Address.ShouldBeEquivalentTo(office.Address);
        }

        [Fact]
        public async Task GetByIdAsync_InvalidId_ReturnNull()
        {
            //Arrange
            var id = new Guid();
            _officeRepository.GetByIdAsync(id, default).ReturnsNull();

            //Act
            var result = await _officeService.GetByIdAsync(id, default);

            //Assert
            await _officeRepository.Received(1).GetByIdAsync(id, default);
            result.ShouldBeNull();
        }

        [Fact]
        public async Task GetAllAsync_ByIsActive_ReturnCollectionOfOffices()
        {
            //Arrange
            var office = _mapper.Map<IEnumerable<OfficeEntity>>(TestOfficeModels.SortOffices(null, null, StandartStatus.Active, default));

            _officeRepository.GetAllAsync(null, null, StandartStatus.Active, Arg.Any<CancellationToken>()).Returns(office);

            //Act
            var result = await _officeService.GetAllAsync(null, null, StandartStatus.Active, new CancellationToken());

            //Assert
            await _officeRepository.Received(1).GetAllAsync(null, null, StandartStatus.Active, Arg.Any<CancellationToken>());
            result.Count().ShouldBeEquivalentTo(1);
        }


        [Fact]
        public async Task CreateAsync_ValidData_ReturnCreatedOffice()
        {
            //Arrange
            var officeEntity = TestOfficeModels.Office;
            var officeModel = _mapper.Map<Office>(officeEntity);

            _officeRepository.AddAsync(Arg.Any<OfficeEntity>(), default).Returns(officeEntity);

            //Act
            var result = await _officeService.CreateAsync(officeModel, default);

            //Assert
            result.Address.ShouldBeEquivalentTo(officeEntity.Address);
        }

        [Fact]
        public async Task CreateAsync_InvalidData_ShouldNotResiveRequest()
        {
            //Arrange
            var officeEntity = TestOfficeModels.Office;
            var officeModel = _mapper.Map<Office>(officeEntity);

            _officeRepository.AddAsync(Arg.Any<OfficeEntity>(), default).ReturnsNull();

            //Act
            await _officeService.CreateAsync(officeModel, default);

            //Assert
            await _officeRepository.DidNotReceive().AddAsync(Arg.Any<OfficeEntity>(), default);
        }

        [Fact]
        public async Task UpdateAsync_ValidData_ReturnUpdatedOffice()
        {
            //Arrange
            var office = TestOfficeModels.Office;
            var changedOffice = _mapper.Map<Office>(office);
            changedOffice.Address = "New address";
            var resultOffice = _mapper.Map<OfficeEntity>(changedOffice);

            _officeRepository.UpdateAsync(Arg.Any<OfficeEntity>(), default).Returns(resultOffice);

            //Act
            var result = await _officeService.UpdateAsync(changedOffice, default);

            //Assert
            result.Address.ShouldBeEquivalentTo(changedOffice.Address);
        }

        [Fact]
        public async Task UpdateAsync_InvalidData_ShouldNotResiveRequest()
        {
            //Arrange
            var office = TestOfficeModels.Office;
            var changedOffice = _mapper.Map<Office>(office);
            changedOffice.Address = "New address";
            var resultOffice = _mapper.Map<OfficeEntity>(changedOffice);

            _officeRepository.UpdateAsync(Arg.Any<OfficeEntity>(), default).ReturnsNull();

            //Act
            await _officeService.UpdateAsync(changedOffice, default);

            //Assert
            await _officeRepository.DidNotReceive().UpdateAsync(Arg.Any<OfficeEntity>(), default);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_ShouldReceiveOneRequest()
        {
            //Arrange
            var id = new Guid();
            var office = TestOfficeModels.Office;

            _officeRepository.GetByIdAsync(id, default).Returns(office);

            //Act
            await _officeService.DeleteAsync(id, default);

            //Assert
            await _officeRepository.Received(1).DeleteAsync(office, default);
        }

        [Fact]
        public async Task DeleteAsync_InvalidId_ShouldResiveRequestWithNull()
        {
            //Arrange
            var id = new Guid();

            _officeRepository.GetByIdAsync(id, default).ReturnsNull();

            //Act
            await _officeService.DeleteAsync(id, default);

            //Assert
            await _officeRepository.Received(1).DeleteAsync(Arg.Do<OfficeEntity>(null), default);
        }
    }
}
