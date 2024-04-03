using Clinic.API.ViewModels.Office;
using Clinic.IntegrationTests.TestData.Offices;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Clinic.IntegrationTests.ApiTests;

public class OfficeControllerTests : IntegrationTestsBase
{
    [Fact]
    public async Task CreateOffice_ValidInput_ReturnsOk()
    {
        var expectedModel = TestOfficeViewModels.CreateOffice();
        var json = JsonConvert.SerializeObject(expectedModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/offices");
        request.Content = content;

        var actualResult = await Client.SendAsync(request);
        var responseResult = await actualResult.Content.ReadAsStringAsync();
        var responseModel = JsonConvert.DeserializeObject<OfficeViewModel>(responseResult);

        actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
        expectedModel.ShouldBeEquivalentTo(responseModel);
    }

    [Fact]
    public async Task CreateOffice_InvalidInput_ReturnsInternalServerError()
    {
        var expectedModel = TestOfficeViewModels.CreateOffice();
        expectedModel.Address = null;

        var json = JsonConvert.SerializeObject(expectedModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var request = new HttpRequestMessage(HttpMethod.Post, $"/api/offices");
        request.Content = content;

        var actualResult = await Client.SendAsync(request);
        var responseResult = await actualResult.Content.ReadAsStringAsync();
        var responseModel = responseResult.Contains("Exception") ? null : JsonConvert.DeserializeObject<OfficeViewModel>(responseResult);

        actualResult.StatusCode.ShouldBe(HttpStatusCode.InternalServerError);
        responseModel.ShouldBeEquivalentTo(null);
    }

    [Fact]
    public async Task GetAllOffices_ReturnsOk()
    {
        List<OfficeViewModel> expectedModelsList = new();

        for (int i = 1; i < 3; i++)
        {
            var createRequest = TestOfficeViewModels.CreateOffice();

            var expectedModel = await CreateOffice(createRequest);

            expectedModelsList.Add(expectedModel!);
        }

        var responseModels = await GetAll();

        responseModels.ShouldNotBeNull();
        foreach (var expectedModel in expectedModelsList)
        {
            responseModels.Select(x => x.Id).ShouldContain(expectedModel.Id);
        }
    }

    [Fact]
    public async Task UpdateOffice_ValidInput_ReturnsOk()
    {
        var createRequest = TestOfficeViewModels.CreateOffice();
        var expectedModel = await CreateOffice(createRequest);
        expectedModel!.Address = Guid.NewGuid().ToString();

        var content = new StringContent(JsonConvert.SerializeObject(expectedModel), Encoding.UTF8, "application/json");
        using var request = new HttpRequestMessage(HttpMethod.Put, $"/api/offices/{expectedModel.Id}");
        request.Content = content;

        var actualResult = await Client.SendAsync(request);
        var responseResult = await actualResult.Content.ReadAsStringAsync();
        var responseModel = JsonConvert.DeserializeObject<OfficeViewModel>(responseResult);

        actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);
        responseModel.ShouldBeEquivalentTo(expectedModel);
    }

    [Fact]
    public async Task DeleteOffice_ValidInput_ReturnsOk()
    {
        var expectedModel = await CreateOffice(TestOfficeViewModels.CreateOffice());

        using var request = new HttpRequestMessage(HttpMethod.Delete, $"/api/offices/{expectedModel!.Id}");

        var actualResult = await Client.SendAsync(request);
        var responseResult = actualResult.Content.ReadAsStringAsync();

        actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);

        var offices = await GetAll();
        offices.ShouldNotBeNull().ShouldNotBeEmpty();
        offices.ShouldNotContain(expectedModel);
    }

    private async Task<OfficeViewModel?> CreateOffice(OfficeViewModel request)
    {
        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var createRequest = new HttpRequestMessage(HttpMethod.Post, $"/api/offices");
        createRequest.Content = content;
        var response = await Client.SendAsync(createRequest);
        response.EnsureSuccessStatusCode();

        var responseResult = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<OfficeViewModel>(responseResult);
    }

    private async Task<IEnumerable<OfficeViewModel>?> GetAll()
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"/api/offices");

        var response = await Client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseResult = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<OfficeViewModel>>(responseResult);
    }
}
