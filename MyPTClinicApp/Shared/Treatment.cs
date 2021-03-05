using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyPTClinicApp.Shared
{
    public class Treatment
    {
        public int ID { get; set; }

        public int PatientID { get; set; }                  // foreign key 

        public int TherapistID { get; set; }                // foreign key 

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public virtual Patient Patient { get; set; }                // navigation property

        public virtual Therapist Therapist { get; set; }            // navigation property
    }
}
