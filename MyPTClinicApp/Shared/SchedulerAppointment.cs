using System;
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
        //public int PatientID { get; set; }                  // foreign key 
        //public int TherapistID { get; set; }                // foreign key 
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        //public List<DateTime> RecurrenceExceptions { get; set; }
        public Guid? RecurrenceId { get; set; }
    }
}
