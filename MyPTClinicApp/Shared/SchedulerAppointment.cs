﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPTClinicApp.Shared
{
    public class SchedulerAppointment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PatientName { get; set; }
        public string TherapistName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public Guid? RecurrenceId { get; set; }
    }
}
