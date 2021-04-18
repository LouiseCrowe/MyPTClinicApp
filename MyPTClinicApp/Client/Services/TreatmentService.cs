using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPTClinicApp.Client.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly HttpClient httpClient;

        public TreatmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Treatment Treatment { get; set; }

        public IEnumerable<Treatment> Treatments { get; set; } = new List<Treatment>();

        public async Task<IEnumerable<TreatmentDTO>> GetTreatments()
        {
            return await httpClient.GetJsonAsync<TreatmentDTO[]>("api/treatments/all");
        }

        public async Task<Treatment> GetTreatmentById(int id)
        {
            return await httpClient.GetJsonAsync<Treatment>($"api/treatments/id/{id}");
        }

        public async Task<IEnumerable<TreatmentDTO>> Search(string searchName, string lastName, DateTime fromDate, DateTime toDate)
        {
            return await httpClient.GetJsonAsync<TreatmentDTO[]>
                ($"api/treatments/search?searchname={searchName}&lastname={lastName}&fromdate={fromDate}&todate={toDate}");
        }

        public async Task<IEnumerable<Treatment>> GetTreatmentsByPatientId(int ID)
        {
            return await httpClient.GetJsonAsync<IEnumerable<Treatment>>($"api/treatments/patientID/{ID}");
        }

        public async Task<IEnumerable<Treatment>> GetTreatmentsByDate(int year, int month, int day)
        {
            return await httpClient.GetJsonAsync<List<Treatment>>($"api/treatments/date/{year}-{month}-{day}");
        }

        public async Task<Treatment> AddTreatment(Treatment treatment)
        {
            var addedTreatment = new StringContent(JsonSerializer.Serialize(treatment), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("api/treatments", addedTreatment);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Treatment>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task<Treatment> UpdateTreatment(Treatment treatment)
        {
            var treatmentJson = new StringContent(JsonSerializer.Serialize(treatment),
                                            Encoding.UTF8, "application/json");

            await httpClient.PutAsync($"api/treatments/id/{treatment.ID}", treatmentJson);

            return null;
        }

        public async Task DeleteTreatment(int treatmentID)
        {
            await httpClient.DeleteAsync($"api/treatments/id/{treatmentID}");
        }        
    }
}
