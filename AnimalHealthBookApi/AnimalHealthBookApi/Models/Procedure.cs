﻿namespace AnimalHealthBookApi.Models
{
    public class Procedure
    {
        public int Id { get; set; }

        public string ProcedureType { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<Medicine>? Medicines { get; set; }

        public int AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }

    }
}
