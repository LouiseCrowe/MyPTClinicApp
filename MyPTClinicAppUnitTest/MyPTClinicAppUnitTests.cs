using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyPTClinicApp.Shared;
using System.Collections.Generic;

namespace MyPTClinicAppUnitTest
{
    [TestClass]
    public class MyPTClinicAppUnitTests
    {
        [TestMethod]
        public void CreateValidPatient()
        {
            // create therapist to assign to Patient

            Therapist t1 = new() { ID = 7, FirstName = "John", LastName = "Murphy", Email = "john@email.com" };

            List<Treatment> treatments = new()
            {
                new Treatment { ID = 4, PatientID = 77, TherapistID = 1, Date = new DateTime(2021, 04, 23, 10, 00, 00), Notes = "Doing well" },
                new Treatment { ID = 6, PatientID = 77, TherapistID = 1, Date = new DateTime(2021, 04, 30, 10, 00, 00), Notes = "Doing well" }
            };

            Patient p1 = new()
            {
                ID = 77,
                TherapistID = 1,
                FirstName = "Niamh",
                LastName = "Brophy",
                DateOfBirth = new DateTime(1974, 04, 23),
                Medications = "Aspirin",
                Gender = Gender.Female,
                Phone = "12345678",
                Email = "louise.crowe7@gmail.com",
                Address = "1 Green Street, Dublin",
                Therapist = t1,
                Treatments = treatments
            };

            Assert.AreEqual(77, p1.ID);
            Assert.AreEqual(1, p1.TherapistID);
            Assert.AreEqual("Niamh", p1.FirstName);
            Assert.AreEqual("Brophy", p1.LastName);
            Assert.AreEqual(new DateTime(1974, 04, 23), p1.DateOfBirth);
            Assert.AreEqual("Aspirin", p1.Medications);
            Assert.AreEqual(Gender.Female, p1.Gender);
            Assert.AreEqual("12345678", p1.Phone);
            Assert.AreEqual("louise.crowe7@gmail.com", p1.Email);
            Assert.AreEqual("1 Green Street, Dublin", p1.Address);
            Assert.AreEqual(t1, p1.Therapist);
            CollectionAssert.AreEqual(treatments, (System.Collections.ICollection)p1.Treatments);
        }


        [TestMethod]
        public void CreateValidPatientDto()
        {
            PatientDto p1 = new()
            {
                ID = 77,
                FirstName = "Niamh",
                LastName = "Brophy",
                Email = "louise.crowe7@gmail.com",
            };

            Assert.AreEqual(77, p1.ID);
            Assert.AreEqual("Niamh", p1.FirstName);
            Assert.AreEqual("Brophy", p1.LastName);
            Assert.AreEqual("louise.crowe7@gmail.com", p1.Email);
        }

        [TestMethod]
        public void CreateValidSchedulerAppointment()
        {
            SchedulerAppointment sa1 = new()
            {
                ID = 1,
                Title = "MT",
                Description = "",
                PatientName = "Patrick Basketball King",
                TherapistName = "Dylan Crowe",
                Start = new DateTime(2021, 04, 23, 10, 00, 00),
                End = new DateTime(2021, 04, 23, 11, 00, 00),
                IsAllDay = false,
                RecurrenceId = null,
                RecurrenceRule = "",
            };

            Assert.AreEqual(1, sa1.ID);
            Assert.AreEqual("MT", sa1.Title);
            Assert.AreEqual("", sa1.Description);
            Assert.AreEqual("Patrick Basketball King", sa1.PatientName);
            Assert.AreEqual("Dylan Crowe", sa1.TherapistName);
            Assert.AreEqual(new DateTime(2021, 04, 23, 10, 00, 00), sa1.Start);
            Assert.AreEqual(new DateTime(2021, 04, 23, 11, 00, 00), sa1.End);
            Assert.AreEqual(false, sa1.IsAllDay);
            Assert.AreEqual("", sa1.RecurrenceRule);
            Assert.AreEqual(null, sa1.RecurrenceId);
        }

        [TestMethod]
        public void CreateValidTherapist()
        {
            List<Patient> patients = new()
            {
                new Patient { ID = 4, FirstName = "Lynda", LastName = "Fallon", TherapistID = 77 },
                new Patient { ID = 5, FirstName = "Laura", LastName = "Baker", TherapistID = 77 },
                new Patient { ID = 6, FirstName = "Sinead", LastName = "Lacey", TherapistID = 77 }
            };

            List<Treatment> treatments = new()
            {
                new Treatment { ID = 8, PatientID = 4, TherapistID = 77, Date = new DateTime(2021, 04, 23, 10, 00, 00), Notes = "Doing well" },
                new Treatment { ID = 9, PatientID = 5, TherapistID = 77, Date = new DateTime(2021, 04, 30, 10, 00, 00), Notes = "Doing well" }
            };


            Therapist t1 = new()
            {
                ID = 77,
                FirstName = "Jack",
                LastName = "Black",
                Phone = "0877774512",
                Email = "dylan@dylancroweclinic.ie",
                Location = "33 Pembroke Street Lower, Dublin 2",
                Patients = patients,
                Treatments = treatments
            };

            Assert.AreEqual(77, t1.ID);
            Assert.AreEqual("Jack", t1.FirstName);
            Assert.AreEqual("Black", t1.LastName);
            Assert.AreEqual("0877774512", t1.Phone);
            Assert.AreEqual("dylan@dylancroweclinic.ie", t1.Email);
            Assert.AreEqual("33 Pembroke Street Lower, Dublin 2", t1.Location);
            CollectionAssert.AreEqual(patients, (System.Collections.ICollection)t1.Patients);
            CollectionAssert.AreEqual(treatments, (System.Collections.ICollection)t1.Treatments);
        }

        [TestMethod]
        public void CreateValidTreatment()
        {
            // set up patient and therapist to assign to treatment
            Patient p1 = new() { ID = 7, FirstName = "Louise", LastName = "Murphy" };
            Therapist therapist1 = new() { ID = 7, FirstName = "John", LastName = "Murphy", Email = "john@email.com" };

            Treatment t1 = new()
            {
                ID = 1,
                PatientID = 7,
                TherapistID = 7,
                Date = new DateTime(2021, 04, 23, 10, 00, 00),
                Notes = "Please update after treatment",
                AppointmentID = 6,
                Patient = p1,
                Therapist = therapist1
            };

            Assert.AreEqual(1, t1.ID);
            Assert.AreEqual(7, t1.PatientID);
            Assert.AreEqual(7, t1.TherapistID);
            Assert.AreEqual(new DateTime(2021, 04, 23, 10, 00, 00), t1.Date);
            Assert.AreEqual("Please update after treatment", t1.Notes);
            Assert.AreEqual(6, t1.AppointmentID);
            Assert.AreEqual(p1, t1.Patient);
            Assert.AreEqual(therapist1, t1.Therapist);
        }

        [TestMethod]
        public void CreateValidTreatmentDto()
        {
            TreatmentDto t1 = new()
            {
                ID = 1,
                Date = new DateTime(2021, 04, 23, 10, 00, 00),
                Notes = "Please update after treatment",
                TherapistId = 3,
                TherapistFirstName = "Dylan",
                TherapistLastName = "Crowe",
                PatientId = 7,
                PatientFirstName = "Louise",
                PatientLastName = "Murphy",
            };

            Assert.AreEqual(1, t1.ID);
            Assert.AreEqual(new DateTime(2021, 04, 23, 10, 00, 00), t1.Date);
            Assert.AreEqual("Please update after treatment", t1.Notes);
            Assert.AreEqual(3, t1.TherapistId);
            Assert.AreEqual("Dylan", t1.TherapistFirstName);
            Assert.AreEqual("Crowe", t1.TherapistLastName);
            Assert.AreEqual(7, t1.PatientId);
            Assert.AreEqual("Louise", t1.PatientFirstName);
            Assert.AreEqual("Murphy", t1.PatientLastName);
        }

    }
}

