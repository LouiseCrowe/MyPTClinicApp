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
    public class TherapistService : ITherapistService
    {
        // inject HttpClient        
        private readonly HttpClient httpClient;

        public TherapistService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
                
        public async Task<IEnumerable<Therapist>> GetTherapists()
        {
            return await httpClient.GetJsonAsync<Therapist[]>("api/therapists/all");
        }

        public async Task<Therapist> GetTherapistById(int therapistId)
        {
            return await httpClient.GetJsonAsync<Therapist>($"api/therapists/id/");
        }

        public Task<Therapist> UpdateTherapist(Therapist therapist)
        {
            //var therapistJson = new StringContent(JsonSerializer.Serialize(therapist), Encoding.UTF8, "application/json");

            //return await httpClient.PutJsonAsync($"api/therapists/id/{therapist.ID}", therapist);
            return null; 
        }

    }
}
