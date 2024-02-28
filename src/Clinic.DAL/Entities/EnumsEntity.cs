using System.Text.Json.Serialization;

namespace Clinic.DAL.Entities
{
    public class EnumsEntity
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum OfficeStatus
        {
            Active,
            Retired
        }
    }
}
