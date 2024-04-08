using StandartCRUD;

namespace Services.API.ViewModels
{
    public record ServiceSearchRequestData(string? Name, StandartStatus? IsActive);
}
