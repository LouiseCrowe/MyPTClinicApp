using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPTClinicApp.Shared
{
    public class PatientDTO
    {
        public int ID { get; set; }

        //public int? TherapistID { get; set; }               // foreign key

        [Required(ErrorMessage = "Please input first name")]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please input Last name")]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string Medications { get; set; }

        public Gender Gender { get; set; }

        [Phone]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Phone { get; set; }

        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Email { get; set; }

        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string Address { get; set; }

        public string TherapistFirstName { get; set; }
        public string TherapistLastName { get; set; }

        public IEnumerable<Treatment> Treatments { get; set; }

        //public virtual Therapist Therapist { get; set; }                    // navigation property

        //public virtual ICollection<Treatment> Treatments { get; set; }      // navigation property
    }
}
