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
        [JsonPropertyName("iD")]
        public int ID { get; set; }

        [JsonPropertyName("patientID")]         // foreign key - int cannot be null
        public int PatientID { get; set; }

        [JsonPropertyName("therapistID")]        // foreign key - int cannot be null   
        public int TherapistID { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Therapist Therapist { get; set; }
    }
}
