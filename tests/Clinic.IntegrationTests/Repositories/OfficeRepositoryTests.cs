using Clinic.DAL.Entities;
using Clinic.DAL.Interfaces;
using Clinic.DAL.Repositories;
using Clinic.IntegrationTests.TestData.Offices;

namespace Clinic.IntegrationTests.Repositories
{
    public class OfficeRepositoryTests : IntegrationTestsBase
    {
        private readonly IOfficeRepository _repository;

        public OfficeRepositoryTests()
        {
            _repository = new OfficeRepository(Context);
        }

        //[Fact]
        //public async Task Create_Entity_ReturnsEntity()
        //{
        //    var entity = TestOfficeEntities.Office;

        //    var actualResult = await _repository.AddAsync(entity, new CancellationToken());

        //    actualResult.ShouldBeEquivalentTo(entity);
        //    Context.Offices.Last().ShouldBeEquivalentTo(entity);
        //}

        //[Fact]
        //public async Task GetAll_Entities_ReturnsEntityCollection()
        //{
            
        //    var ent = await _repository.AddAsync(new() { Id = new Guid("b37b1e25-8a6f-48dd-965b-0581911bb382"), Address = "123", RegistryPhoneNumber = "123", IsActive = OfficeStatus.Active}, new CancellationToken());
        //    var entities = TestOfficeEntities.OfficeEntityCollection;
        //    var actualResult = await _repository.GetAllAsync(new CancellationToken());

        //    actualResult.First().Id.ShouldBeEquivalentTo(ent.Id);
        //}

        //[Fact]
        //public async Task Update_Entity_ReturnsEntity()
        //{
        //    var entity = TestOfficeEntities.Office;
        //    entity.RegistryPhoneNumber = "375296475784";

        //    var actualResult = await _repository.UpdateAsync(entity, new CancellationToken());
        //    var entityToChange = TestOfficeEntities.UpdatedOffice;

        //    actualResult.ShouldBeEquivalentTo(entityToChange);
        //}
    }
}
