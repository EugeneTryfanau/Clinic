﻿using StandartCRUD;

namespace Clinic.DAL.Entities
{
    public class ReceptionistEntity : Entity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? MiddleName { get; set; }

        public Guid? AccountId { get; set; }
        public Guid? OfficeId { get; set; }

        public virtual AccountEntity? Account { get; set; }
        public virtual OfficeEntity? Office { get; set; }
    }
}
