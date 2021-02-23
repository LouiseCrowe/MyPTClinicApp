using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyPTClinicApp.Shared
{
    public class Client
    {
        [JsonPropertyName("iD")]
        public int ID { get; set; }

        // EF will know this is a foreign key to Therapist table
        // because of naming convention <DbSet>/table name followed 
        // by ID
        [JsonPropertyName("therapistID")]
        public int? TherapistID { get; set; }

        [JsonPropertyName("firstName")]
        [Required(ErrorMessage = "Please input first name")]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        [Required(ErrorMessage = "Please input Last name")]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string LastName { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonPropertyName("medications")]
        public string Medications { get; set; }

        [JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        [JsonPropertyName("phone")]
        [Phone]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Phone { get; set; }

        [JsonPropertyName("emailAddress")]
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string Address { get; set; }

        // navigation property to Therapist for this client
        public virtual Therapist Therapist { get; set; }
    }
}
