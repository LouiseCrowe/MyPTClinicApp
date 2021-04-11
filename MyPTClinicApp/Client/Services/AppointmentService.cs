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
    public class AppointmentService : IAppointmentService
    {
        private readonly HttpClient httpClient;

        public AppointmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<SchedulerAppointment>> Read()
        {
            return await httpClient.GetJsonAsync<List<SchedulerAppointment>>("api/schedulerappointments");
        }

        public async Task Create(SchedulerAppointment itemToInsert)
        {
            var addedAppointment =
           new StringContent(JsonSerializer.Serialize(itemToInsert), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("api/schedulerappointments", addedAppointment);            
        }

        public async Task Delete(SchedulerAppointment itemToDelete)
        {
            var response = await httpClient.DeleteAsync($"api/schedulerappointments/{itemToDelete.ID}");
        }       

        public async Task Update(SchedulerAppointment itemToUpdate)
        {
            var appointmentJson = new StringContent(JsonSerializer.Serialize(itemToUpdate),
                                           Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"api/schedulerappointments/{itemToUpdate.ID}", appointmentJson);
        }
    }
}
