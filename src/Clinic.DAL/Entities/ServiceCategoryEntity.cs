using StandartCRUD.StandartDAL.Entities;

namespace Clinic.DAL.Entities
{
    public class ServiceCategoryEntity : Entity
    {
        public required string CategoryName { get; set; }
        public DateTime TimeSlotSize { get; set; }
    }
}
