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
        [JsonPropertyName("iD")]
        public int ID { get; set; }


        [JsonPropertyName("firstName")]
        [Required(ErrorMessage = "Please input first name")]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        [Required(ErrorMessage = "Please input Last name")]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string LastName { get; set; }

        [JsonPropertyName("phone")]
        [Phone]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Phone { get; set; }

        [JsonPropertyName("emailAddress")]
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Email { get; set; }

        [JsonPropertyName("location")]
        [MaxLength(150, ErrorMessage = "Cannot exceed 150 characters")]
        public string Location { get; set; }

    }
}
