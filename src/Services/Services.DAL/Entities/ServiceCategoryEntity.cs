using StandartCRUD.StandartDAL.Entities;

namespace Services.DAL.Entities
{
    public class ServiceCategoryEntity : Entity
    {
        public required string CategoryName { get; set; }
        public DateTime TimeSlotSize { get; set; }
    }
}
