using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPTClinicApp.Client.Services;
using MyPTClinicApp.Shared;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;

namespace MyPTClinicAppbUnitTests
{
    [TestClass]
    public class MyPTClinicAppbUnitTests
    {
        [Inject]
        public ITherapistService TherapistService { get; set; }

        [TestMethod]
        public void HomePageRendersCorrectlyForAuthorisedUser()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();

            ctx.Services.AddApiAuthorization();
       
            // set user and authenticated and authorised
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");

            // Act
            var cut = ctx.RenderComponent<MyPTClinicApp.Client.Pages.Index>();

            var renderMarkup = cut.Markup;

            var renderMarkupText = renderMarkup.Trim();

            // Assert
            StringAssert.Contains(renderMarkupText, "Welcome to MyPTClinicApp");
            StringAssert.Contains(renderMarkupText, "Appointments");
            StringAssert.Contains(renderMarkupText, "Manage Appointments");
            StringAssert.Contains(renderMarkupText, "Reminders");
            StringAssert.Contains(renderMarkupText, "Email Reminders");
            StringAssert.Contains(renderMarkupText, "Treatments");
            StringAssert.Contains(renderMarkupText, "Update Treatment Notes");
            StringAssert.Contains(renderMarkupText, "Add Patient");
            StringAssert.Contains(renderMarkupText, "Add a new patient");
        }

        [TestMethod]
        public void HomePageRendersCorrectlyForUnAuthorisedUser()
        {
            // Arrange
            using var ctx = new Bunit.TestContext();

            ctx.Services.AddApiAuthorization();

            // set user and authenticated and authorised
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER", AuthorizationState.Unauthorized);

            // Act
            var cut = ctx.RenderComponent<MyPTClinicApp.Client.Pages.Index>();

            var renderMarkup = cut.Markup;

            // Assert
            StringAssert.Contains(renderMarkup, "Login to MyPTClinicApp");
        }


        [TestMethod]
        public void TherapistPageRendersCorrectly()
        {
            using var ctx = new Bunit.TestContext();
            
            // arrrange MockMessageHandler



            var mock = ctx.Services.AddMockHttpClient();
            mock.When("http://localhost/api/therapists/all").RespondJsonTherapist(new List<Therapist>

            { new Therapist() {
                FirstName = "Dylan",
                LastName = "Crowe",
                Email = "dylan@dylancroweclinic.ie",
                Location = "33 Pembroke Street"},
               new Therapist() {
                FirstName = "Emily",
                LastName = "Wanda",
                Email = "emily@email.ie",
                Location = "33 Pembroke Street"}
            });

            // Register services
            ctx.AddTestAuthorization();
            
            // set user and authenticated and authorised
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");
            
            
            ctx.Services.AddScoped<ITherapistService, TherapistService>();
            // Act
            var cut = ctx.RenderComponent<MyPTClinicApp.Client.Pages.TherapistOverview>();

            // Assert that it renders the initial loading message
            var renderMarkup = cut.Markup;
                   
            // Assert
            StringAssert.Contains(renderMarkup, "All Therapists");
            StringAssert.Contains(renderMarkup, "Retrieving therapist information, it will just take a moment...");


            mock.ToHttpClient();
            

            //Figure out how to load data 

            //Thread.Sleep(3000);

            //StringAssert.Contains(renderMarkupText, "Dylan");

            //// handle async method
            //var therapistService = new TaskCompletionSource<string>();
            //var updatedCut = ctx.RenderComponent<TherapistOverview>();


            //var updatedRenderMarkup = cut.Markup;

            //cut.WaitForAssertion(() => StringAssert.Contains(renderMarkup, "Dylan Crowe"), new TimeSpan(3000));
        }




        [TestMethod]
        public void TherapistPageSearchButton()
        {
            using var ctx = new Bunit.TestContext();

            var mock = ctx.Services.AddMockHttpClient();
            mock.When("http://localhost/api/therapists/all").RespondJsonTherapist(new List<Therapist>

            { new Therapist() {
                FirstName = "Dylan",
                LastName = "Crowe",
                Email = "dylan@dylancroweclinic.ie",
                Location = "33 Pembroke Street"},
               new Therapist() {
                FirstName = "Emily",
                LastName = "Wanda",
                Email = "emily@email.ie",
                Location = "33 Pembroke Street"}
            });

            // Arrange
            // Register services
            ctx.AddTestAuthorization();

            // set user and authenticated and authorised
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("TEST USER");

            ctx.Services.AddScoped<ITherapistService, TherapistService>();
            var cut = ctx.RenderComponent<MyPTClinicApp.Client.Pages.TherapistOverview>();
            var searchButton = cut.Find("button");
            var inputField = cut.Find("input");

            // Act  
            // don't input a search name
            searchButton.Click();

            // Assert
            // Re-render page
            cut.Render();

            var renderMarkup = cut.Markup;

            StringAssert.Contains(renderMarkup, "Name not found - maybe check your spelling or try another name");

            // search for existing Therapist
            inputField.Change("Dylan");
            searchButton.Click();
            StringAssert.Contains(renderMarkup, "Dylan");
            StringAssert.Contains(renderMarkup, "Crowe");


            // search for non-existing Therapist
            inputField.Change("Missing");
            searchButton.Click();
            StringAssert.Contains(renderMarkup, "Name not found - maybe check your spelling or try another name");

            inputField.Change("Em");
            searchButton.Click();
            StringAssert.Contains(renderMarkup, "Emily");
            StringAssert.Contains(renderMarkup, "Wanda");

            inputField.Change("Missing");
            searchButton.Click();
            StringAssert.Contains(renderMarkup, "Name not found - maybe check your spelling or try another name");            
        }

        [TestMethod]
        public void TreatmentPageRendersCorrectly()
        {
            using var ctx = new Bunit.TestContext();
            var mock = ctx.Services.AddMockHttpClient();
            mock.When("/getData").RespondJson(new List<Treatment>

            { new Treatment() {
                 PatientID = 1,
                 TherapistID = 2,
                 AppointmentID = 1,
                 Date = new DateTime(2021, 5, 12, 9, 0, 0)
            },
               new Treatment() {
                 PatientID = 1,
                 TherapistID = 2,
                 AppointmentID = 1,
                 Date = new DateTime(2021, 5, 12, 9, 0, 0)
            }
            });

            // Register services
            ctx.AddTestAuthorization();
            ctx.Services.AddScoped<ITreatmentService, TreatmentService>();

            var cut = ctx.RenderComponent<MyPTClinicApp.Client.Pages.TreatmentOverview>();
            var h1Elm = cut.Find("h1");

            // Act
            var h1ElmText = h1Elm.TextContent;

            // Assert
            h1ElmText.MarkupMatches("All Treatments");


            var button = cut.Find("btn-primary");
            button.Click();



        }



        // Counter Component Deleted - just for reference
        //[TestMethod]
        //public void CounterShouldIncrementWhenSelected()
        //{
        //    // Arrange
        //    using var ctx = new Bunit.TestContext();
        //    var cut = ctx.RenderComponent<Counter>();
        //    var paraElm = cut.Find("p");

        //    // Act
        //    cut.Find("button").Click();
        //    var paraElmText = paraElm.TextContent;

        //    // Assert
        //    paraElmText.MarkupMatches("Current count: 1");
        //}
    }
}