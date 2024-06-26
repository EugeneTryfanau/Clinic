﻿using Clinic.API.ViewModels.Office;
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
        var expectedModel = await CreateOffice(TestOfficeViewModels.CreateOffice());
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
        OfficeViewModel? invalidRequest = null;

        var content = new StringContent(JsonConvert.SerializeObject(invalidRequest), Encoding.UTF8, "application/json");
        using var request = new HttpRequestMessage(HttpMethod.Post, "/api/offices");
        request.Content = content;

        var actualResult = await Client.SendAsync(request);

        actualResult.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetAllOffices_ReturnsOk()
    {
        List<OfficeViewModel> expectedModelsList = new();

        for (int i = 1; i < 3; i++)
        {
            var expectedModel = await CreateOffice(TestOfficeViewModels.CreateOffice());

            expectedModelsList.Add(expectedModel!);
        }

        var actualResult = await Client.GetAsync("/api/offices");
        actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);

        var responseModels = JsonConvert.DeserializeObject<IEnumerable<OfficeViewModel>>(await actualResult.Content.ReadAsStringAsync());
        responseModels.ShouldNotBeNull();
        foreach (var expectedModel in responseModels)
        {
            responseModels.Select(x => x.Id).ShouldContain(expectedModel.Id);
        }
    }

    [Fact]
    public async Task GetAllOffices_ReturnsSameCollectionFromCache()
    {
        List<OfficeViewModel> expectedModelsList = new();

        for (int i = 1; i < 3; i++)
        {
            var expectedModel = await CreateOffice(TestOfficeViewModels.CreateOffice());

            expectedModelsList.Add(expectedModel!);
        }

        var actualResult = await Client.GetAsync("/api/offices");
        actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);

        var responseModels = JsonConvert.DeserializeObject<IEnumerable<OfficeViewModel>>(await actualResult.Content.ReadAsStringAsync());

        await CreateOffice(TestOfficeViewModels.CreateOffice());

        var actualResultSecondRequest = await Client.GetAsync("/api/offices");
        actualResultSecondRequest.StatusCode.ShouldBe(HttpStatusCode.OK);

        var responseModelsSecondRequest = JsonConvert.DeserializeObject<IEnumerable<OfficeViewModel>>(await actualResultSecondRequest.Content.ReadAsStringAsync());

        responseModels.ShouldNotBeNull();
        responseModelsSecondRequest.ShouldNotBeNull();
        responseModels.ShouldBeEquivalentTo(responseModelsSecondRequest);
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

        actualResult.StatusCode.ShouldBe(HttpStatusCode.OK);

        var offices = await GetAll();
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
