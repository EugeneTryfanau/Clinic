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

        [Fact]
        public async Task Create_Entity_ReturnsEntity()
        {
            var entity = TestOfficeEntities.Office;

            var actualResult = await _repository.AddAsync(entity, new CancellationToken());

            actualResult.ShouldBeEquivalentTo(entity);
            Context.Offices.Last().ShouldBeEquivalentTo(entity);
        }
    }
}
