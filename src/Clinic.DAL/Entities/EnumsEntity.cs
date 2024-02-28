using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Clinic.DAL.Entities
{
    public class EnumsEntity
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [DefaultValue(OfficeStatus.Inactive)]
        public enum OfficeStatus
        {
            Inactive,
            Active
        }
    }
}
