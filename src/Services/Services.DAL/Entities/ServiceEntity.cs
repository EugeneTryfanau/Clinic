using StandartCRUD;

namespace Services.DAL.Entities
{
    public class ServiceEntity : Entity
    {
        public required string ServiceName { get; set; }
        public decimal Price { get; set; }
        public StandartStatus IsActive { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual ServiceCategoryEntity? Category { get; set; }
    }
}
