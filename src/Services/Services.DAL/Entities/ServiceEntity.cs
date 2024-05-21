using StandartCRUD;
using StandartCRUD.StandartDAL.Entities;

namespace Services.DAL.Entities
{
    public class ServiceEntity : Entity
    {
        public required string ServiceName { get; set; }
        public double Price { get; set; }
        public StandartStatus IsActive { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual ServiceCategoryEntity? Category { get; set; }
    }
}
