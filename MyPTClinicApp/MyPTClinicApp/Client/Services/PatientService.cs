using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient httpClient;

        public PatientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Patient Patient { get; set; }

        public async Task<PatientDTO> GetPatientById(int id)
        {
            return await httpClient.GetJsonAsync<PatientDTO>($"api/patients/id/{id}");
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await httpClient.GetJsonAsync<Patient[]>("api/patients/all");
        }

        public async Task<IEnumerable<Patient>> GetPatientsByTherapistId(int ID)
        {
            return await httpClient.GetJsonAsync<Patient[]>($"api/patients/therapistID/{ID}");
        }
    }
}
