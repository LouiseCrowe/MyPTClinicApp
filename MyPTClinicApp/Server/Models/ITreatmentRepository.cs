﻿using MyPTClinicApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPTClinicApp.Server.Models
{
    public interface ITreatmentRepository
    {
        IQueryable<TreatmentDto> GetTreatments();
        Task<IEnumerable<TreatmentDto>> Search(string searchName, string lastName, DateTime fromDate, DateTime toDate);
        Task<Treatment> GetTreatmentById(int treatmentId);
        IEnumerable<Treatment> GetTreatmentsByPatientId(int patientId);
        Task<IEnumerable<Treatment>> GetTreatmentsByDate(DateTime appointmentsDate);
        Task<Treatment> AddTreatment(Treatment treatment);
        Task<Treatment> UpdateTreatment(Treatment treatment);
        Task<Treatment> DeleteTreatment(int treatmentId);
    }
}
