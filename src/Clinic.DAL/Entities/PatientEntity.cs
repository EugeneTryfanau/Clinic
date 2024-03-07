﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.DAL.Entities
{
    public class PatientEntity : Entity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string MiddleName { get; set; }
        public bool IsLinkedToAccount { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid? AccountId { get; set; }

        public virtual AccountEntity? Account { get; set; }

        public virtual ICollection<AppointmentEntity>? Appointments { get; set; }
    }
}
