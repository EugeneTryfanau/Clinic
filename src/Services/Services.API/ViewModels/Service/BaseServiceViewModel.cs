using StandartCRUD;

namespace Services.API.ViewModels.Service
{
    public class BaseServiceViewModel
    {
        public string? ServiceName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public StandartStatus IsActive { get; set; }

        public Guid? CategoryId { get; set; } = Guid.Empty;
    }
}
