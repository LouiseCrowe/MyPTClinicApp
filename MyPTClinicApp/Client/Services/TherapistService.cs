using Microsoft.AspNetCore.Components;
using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<IEnumerable<Therapist>> Search(string searchName, string lastName)
        {
            return await httpClient.GetJsonAsync<Therapist[]>($"api/therapists/search?searchname={searchName}&lastname={lastName}");
        }

        public async Task<Therapist> GetTherapistById(int therapistId)
        {
            return await httpClient.GetJsonAsync<Therapist>($"api/therapists/id/{therapistId}");
        }

        public async Task<Therapist> AddTherapist(Therapist therapist)
        {   
            var addedTherapist =
            new StringContent(JsonSerializer.Serialize(therapist), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("api/therapists", addedTherapist);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Therapist>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task<Therapist> UpdateTherapist(Therapist updatedTherapist)
        {
            var therapistJson = new StringContent(JsonSerializer.Serialize(updatedTherapist),
                                            Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"api/therapists/id/{updatedTherapist.ID}", therapistJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Therapist>(await response.Content.ReadAsStreamAsync());
            }
           
            return null;
        }

        public async Task<string> DeleteTherapist(int therapistID)
        {
            var response = await httpClient.DeleteAsync($"api/therapists/id/{therapistID}");

            if (response.IsSuccessStatusCode)
            {
                return "saved";
            }

            return "notsaved";
        }

        
    }
}
