using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyPTClinicApp.Shared
{
    public class Therapist
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please input therapist's first name")]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please input therapist's last name")]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string LastName { get; set; }

        [Phone]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Phone { get; set; }

        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Email { get; set; }

        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string Location { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }              // navigation property

        public virtual ICollection<Treatment> Treatments { get; set; }          // navigation property
    }
}
