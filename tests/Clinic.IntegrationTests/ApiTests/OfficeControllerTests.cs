using Clinic.DAL.Entities;
using Clinic.IntegrationTests.TestData.Offices;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Clinic.IntegrationTests.ApiTests
{
    public class OfficeControllerTests : IntegrationTestsBase
    {
        private static OfficeEntity TestEntity { get; set; }

        [Fact]
        public async Task CreateOffice_ValidInput_ReturnsOk()
        {
            var entity = TestOfficeModels.CreateOfficeRequest;
            var json = JsonConvert.SerializeObject(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/Offices");
            request.Content = content;
            
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.Content.ReadAsStringAsync();

            TestEntity = JsonConvert.DeserializeObject<OfficeEntity>(responseResult.Result);

            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            TestEntity.Address.ShouldBeEquivalentTo(entity.Address);
            TestEntity.RegistryPhoneNumber.ShouldBeEquivalentTo(entity.RegistryPhoneNumber);
            TestEntity.IsActive.ShouldBeEquivalentTo(entity.IsActive);
            Context.Offices.Last().ShouldBeEquivalentTo(TestEntity);
        }

        [Fact]
        public async Task GetAllOffices_ReturnsOk()
        {
            Thread.Sleep(2000);
            using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/Offices");
            
            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.Content.ReadAsStringAsync();

            var resultEntities = JsonConvert.DeserializeObject<IEnumerable<OfficeEntity>>(responseResult.Result);

            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            Context.Offices.First().ShouldBeEquivalentTo(TestEntity);
        }

        [Fact]
        public async Task UpdateOffice_ValidInput_ReturnsOk()
        {
            Thread.Sleep(4000);
            var entity = TestOfficeModels.CreateOfficeRequest;
            entity.Id = TestEntity.Id;
            var json = JsonConvert.SerializeObject(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/Offices/{TestEntity.Id}");
            request.Content = content;

            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.Content.ReadAsStringAsync();

            var resultEntity = JsonConvert.DeserializeObject<OfficeEntity>(responseResult.Result);

            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            resultEntity.Id.ShouldBeEquivalentTo(TestEntity.Id);
            resultEntity.Address.ShouldBeEquivalentTo(entity.Address);
            resultEntity.RegistryPhoneNumber.ShouldBeEquivalentTo(entity.RegistryPhoneNumber);
            resultEntity.IsActive.ShouldBeEquivalentTo(entity.IsActive);
        }

        [Fact]
        public async Task DeleteOffice_ValidInput_ReturnsOk()
        {
            Thread.Sleep(6000);

            using var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/Offices/{TestEntity.Id}");

            var actualResult = await Client.SendAsync(request);
            var responseResult = actualResult.Content.ReadAsStringAsync();

            actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
            Context.Offices.ToList().ShouldBeEmpty();
        }
    }
}
