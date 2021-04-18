using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await httpClient.GetJsonAsync<Patient[]>("api/patients/all");
        }

        public async Task<IEnumerable<String>> GetAllPatientsFullNames()
        {
            return await httpClient.GetJsonAsync<List<String>>("api/patients/fullnames");
        }


        public async Task<Patient> GetPatientById(int id)
        {
            return await httpClient.GetJsonAsync<Patient>($"api/patients/id/{id}");
        }

        //find patient by fullname (from appointment)
        public async Task<PatientDTO> GetPatientNameAndEmail(string firstName, string lastName)
        {
            return await httpClient.GetJsonAsync<PatientDTO>($"api/patients/nameandemail/{firstName}/{lastName}");
        }

        public async Task<IEnumerable<Patient>> Search(string searchName, string lastName)
        {
            return await httpClient.GetJsonAsync<Patient[]>($"api/patients/search?searchname={searchName}&lastname={lastName}");
        }

        public async Task<IEnumerable<Patient>> GetPatientsByTherapistId(int ID)
        {
            return await httpClient.GetJsonAsync<Patient[]>($"api/patients/therapistID/{ID}");
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            var addedPatient =
            new StringContent(JsonSerializer.Serialize(patient), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("api/patients", addedPatient);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Patient>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            var patientJson = new StringContent(JsonSerializer.Serialize(patient),
                                            Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"api/patients/id/{patient.ID}", patientJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Patient>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeletePatient(int patientID)
        {
            await httpClient.DeleteAsync($"api/patients/id/{patientID}");
        }
    }
}
