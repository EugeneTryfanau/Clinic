using StandartCRUD;

namespace Services.API.ViewModels.Service
{
    public class BaseServiceViewModel
    {
        public required string ServiceName { get; set; }
        public decimal Price { get; set; }
        public StandartStatus IsActive { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
