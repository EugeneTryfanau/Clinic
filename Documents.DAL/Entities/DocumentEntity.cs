using StandartCRUD.StandartDAL.Entities;

namespace Documents.DAL.Entities
{
    public class DocumentEntity : Entity
    {
        public string? Url { get; set; }

        public Guid ResultId { get; set; }
    }
}
