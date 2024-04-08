using StandartCRUD.StandartDAL.Entities;

namespace Clinic.DAL.Entities
{
    public class DocumentEntity : Entity
    {
        public required string Url { get; set; }

        public Guid? ResultId { get; set; }

        public virtual ResultEntity? Result { get; set; }
    }
}
