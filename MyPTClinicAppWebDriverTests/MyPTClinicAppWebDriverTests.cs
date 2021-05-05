using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyPTClinicAppWebDriverTests
{
    [TestClass]
    public class MyPTClinicAppWebDriverTests
    {
        // Constants for URLs in application
        private const string HomeUrl = "https://myptclinicappapi.azurewebsites.net/";
        private const string AppointmentsUrl = "https://myptclinicappapi.azurewebsites.net/scheduleroverview";
        private const string TreatmentsUrl = "https://myptclinicappapi.azurewebsites.net/treatmentoverview";
        private const string RemindersUrl = "https://myptclinicappapi.azurewebsites.net/appointmentreminders";
        private const string PatientsUrl = "https://myptclinicappapi.azurewebsites.net/patientoverview";
        private const string AddPatientUrl = "https://myptclinicappapi.azurewebsites.net/patientedit";
        private const string TherapistsUrl = "https://myptclinicappapi.azurewebsites.net/therapistoverview";
        private const string MonthlyStatsUrl = "https://myptclinicappapi.azurewebsites.net/chart";
        private const string LoggedOutUrl = "https://myptclinicappapi.azurewebsites.net/authentication/logged-out";


        private const string duplicatePatientError = "Patient name already in use. Please try again.";

        [TestMethod]
        public void LoginWithValidDetails()
        {
            using IWebDriver driver = new ChromeDriver();
                //Explicit waits
            WebDriverWait wait = new (driver, TimeSpan.FromSeconds(20));

            driver.Navigate().GoToUrl(HomeUrl);

            Assert.AreEqual(HomeUrl, driver.Url);

            // can use prebuilt conditions
            IWebElement loginButton1 =
                wait.Until(d => d.FindElement(By.LinkText("Log in")));

            loginButton1.Click();

            IWebElement email =
                    wait.Until(d => d.FindElement(By.Id("Input_Email")));

            email.SendKeys("louise.crowe7@gmail.com");

            IWebElement password =
                wait.Until(d => d.FindElement(By.Id("Input_Password")));

            password.SendKeys("Manutd77*");

            IWebElement loginButton2 =
                wait.Until(d => d.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[5]/button")));

            loginButton2.Click();

            // confirm that user has logged - username on screen
            IWebElement userLoggedIn = wait.Until(d => d.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/a")));

            string userLoggedInText = userLoggedIn.Text;

            Assert.AreEqual("Hello, louise.crowe7@gmail.com!", userLoggedInText);
            
        }

        [TestMethod]
        public void LoginWithInvalidUsername()
        {
            using IWebDriver driver = new ChromeDriver();
            //Explicit waits
            WebDriverWait wait = new (driver, TimeSpan.FromSeconds(20));

            driver.Navigate().GoToUrl(HomeUrl);

            // can use prebuilt conditions
            IWebElement loginButton1 =
                wait.Until(d => d.FindElement(By.LinkText("Log in")));

            loginButton1.Click();

            IWebElement email =
                    wait.Until(d => d.FindElement(By.Id("Input_Email")));

            email.SendKeys("invalid@gmail.com");

            IWebElement password =
                wait.Until(d => d.FindElement(By.Id("Input_Password")));

            password.SendKeys("Manutd77*");

            IWebElement loginButton2 =
                wait.Until(d => d.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[5]/button")));

            loginButton2.Click();

            // Error message displayed
            IWebElement errorMessage = wait.Until(d => d.FindElement(By.ClassName("validation-summary-errors")));

            string errorMessageText = errorMessage.Text;

            Assert.AreEqual("Invalid login attempt.", errorMessageText);            
        }

        [TestMethod]
        public void LoginWithInvalidPassword()
        {
            using IWebDriver driver = new ChromeDriver();
            //Explicit waits
            WebDriverWait wait = new (driver, TimeSpan.FromSeconds(20));

            driver.Navigate().GoToUrl(HomeUrl);

            // can use prebuilt conditions
            IWebElement loginButton1 =
                wait.Until(d => d.FindElement(By.LinkText("Log in")));

            loginButton1.Click();

            IWebElement email =
                    wait.Until(d => d.FindElement(By.Id("Input_Email")));

            email.SendKeys("louise.crowe7@gmail.com");

            IWebElement password =
                wait.Until(d => d.FindElement(By.Id("Input_Password")));

            password.SendKeys("password");

            IWebElement loginButton2 =
                wait.Until(d => d.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[5]/button")));

            loginButton2.Click();

            // Error message displayed
            IWebElement errorMessage = wait.Until(d => d.FindElement(By.ClassName("validation-summary-errors")));

            string errorMessageText = errorMessage.Text;

            Assert.AreEqual("Invalid login attempt.", errorMessageText);            
        }


        [TestMethod]
        public void NavigateApplication()
        {
            using IWebDriver driver = new ChromeDriver();
            //Explicit waits
            WebDriverWait wait = new (driver, TimeSpan.FromSeconds(20));

            driver.Navigate().GoToUrl(HomeUrl);


            // can use prebuilt conditions
            IWebElement loginButton1 =
                wait.Until(d => d.FindElement(By.LinkText("Log in")));

            loginButton1.Click();

            IWebElement email =
                    wait.Until(d => d.FindElement(By.Id("Input_Email")));

            email.SendKeys("louise.crowe7@gmail.com");

            IWebElement password =
                wait.Until(d => d.FindElement(By.Id("Input_Password")));

            password.SendKeys("Manutd77*");

            IWebElement loginButton2 =
                wait.Until(d => d.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[5]/button")));

            loginButton2.Click();

            // confirm that user has logged - username on screen
            IWebElement userLoggedIn = wait.Until(d => d.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/a")));

            string userLoggedInText = userLoggedIn.Text;

            Assert.AreEqual("Hello, louise.crowe7@gmail.com!", userLoggedInText);

            // Navigate to Appointments
            IWebElement appointmentsURL = wait.Until(d => d.FindElement(By.LinkText("Appointments")));

            appointmentsURL.Click();

            IWebElement todayTitle = wait.Until(d => d.FindElement(By.ClassName("k-button")));

            string todayTitleText = todayTitle.Text;

            Assert.AreEqual(AppointmentsUrl, driver.Url);
            Assert.AreEqual("Today", todayTitleText);

            // Navigate to Treatments
            IWebElement treatmentsURL = wait.Until(d => d.FindElement(By.LinkText("Treatments")));

            treatmentsURL.Click();

            IWebElement treatmentsTitle = wait.Until(d => d.FindElement(By.ClassName("page-title")));

            string treatmentsTitleText = treatmentsTitle.Text;

            Assert.AreEqual(TreatmentsUrl, driver.Url);
            Assert.AreEqual("All Treatments", treatmentsTitleText);

            // Navigate to Reminders
            IWebElement remindersURL = wait.Until(d => d.FindElement(By.LinkText("Reminders")));

            remindersURL.Click();

            IWebElement remindersTitle = wait.Until(d => d.FindElement(By.ClassName("page-title")));

            string remindersTitleText = remindersTitle.Text;

            Assert.AreEqual(RemindersUrl, driver.Url);
            Assert.AreEqual("Send Email Reminders for Appointments", remindersTitleText);

            // Navigate to Patients
            IWebElement patientsURL = wait.Until(d => d.FindElement(By.LinkText("Patients")));

            patientsURL.Click();

            IWebElement patientsTitle = wait.Until(d => d.FindElement(By.ClassName("page-title")));

            string patientsTitleText = patientsTitle.Text;

            Assert.AreEqual(PatientsUrl, driver.Url);
            Assert.AreEqual("All Patients", patientsTitleText);

            // Navigate to Add Patient
            IWebElement addPatientURL = wait.Until(d => d.FindElement(By.LinkText("Add Patient")));

            addPatientURL.Click();

            IWebElement addPatientsTitle = wait.Until(d => d.FindElement(By.ClassName("page-title")));

            string addPatientsTitleText = addPatientsTitle.Text;

            Assert.AreEqual(AddPatientUrl, driver.Url);
            Assert.AreEqual("Patient Details:", addPatientsTitleText);

            // Navigate to Therapists
            IWebElement therapistsURL = wait.Until(d => d.FindElement(By.LinkText("Therapists")));

            therapistsURL.Click();

            IWebElement therapistsTitle = wait.Until(d => d.FindElement(By.ClassName("page-title")));

            string therapistsTitleText = therapistsTitle.Text;

            Assert.AreEqual(TherapistsUrl, driver.Url);
            Assert.AreEqual("All Therapists", therapistsTitleText);

            // Navigate to Monthly Stats
            IWebElement monthlyStatsURL = wait.Until(d => d.FindElement(By.LinkText("Monthly Stats")));

            monthlyStatsURL.Click();

            IWebElement monthlyStatsTitle = wait.Until(d => d.FindElement(By.ClassName("page-title")));

            string monthlyStatsTitleText = monthlyStatsTitle.Text;

            Assert.AreEqual(MonthlyStatsUrl, driver.Url);
            Assert.AreEqual("Comparing Monthly Treatment Totals for 2020 and 2021", monthlyStatsTitleText);            
        }


        [TestMethod]
        public void Logout()
        {
            using IWebDriver driver = new ChromeDriver();
            //Explicit waits
            WebDriverWait wait = new (driver, TimeSpan.FromSeconds(20));

            driver.Navigate().GoToUrl(HomeUrl);

            // can use prebuilt conditions
            IWebElement loginButton1 =
                wait.Until(d => d.FindElement(By.LinkText("Log in")));

            loginButton1.Click();

            IWebElement email =
                    wait.Until(d => d.FindElement(By.Id("Input_Email")));

            email.SendKeys("louise.crowe7@gmail.com");

            IWebElement password =
                wait.Until(d => d.FindElement(By.Id("Input_Password")));

            password.SendKeys("Manutd77*");

            IWebElement loginButton2 =
                wait.Until(d => d.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[5]/button")));

            loginButton2.Click();

            // confirm logout button has loaded
            IWebElement logoutLink = wait.Until(d => d.FindElement(By.LinkText("Logout")));

            logoutLink.Click();

            IWebElement logoutTitle = wait.Until(d => d.FindElement(By.TagName("h3")));

            string logoutTitleText = logoutTitle.Text;

            Assert.AreEqual("Logged out, enjoy your day!", logoutTitleText);
            Assert.AreEqual(LoggedOutUrl, driver.Url);
        }

        [TestMethod]
        public void AddPatient()
        {
            using IWebDriver driver = new ChromeDriver();
            //Explicit waits
            WebDriverWait wait = new (driver, TimeSpan.FromSeconds(10));

            // Log into application
            driver.Navigate().GoToUrl(HomeUrl);

            // can use prebuilt conditions
            IWebElement loginButton1 =
                wait.Until(d => d.FindElement(By.LinkText("Log in")));

            loginButton1.Click();

            IWebElement email =
                wait.Until(d => d.FindElement(By.Id("Input_Email")));

            email.SendKeys("louise.crowe7@gmail.com");

            IWebElement password =
                wait.Until(d => d.FindElement(By.Id("Input_Password")));

            password.SendKeys("Manutd77*");

            IWebElement loginButton2 =
                wait.Until(d => d.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[5]/button")));

            loginButton2.Click();

            // add patient

            IWebElement addPatientBtn =
            wait.Until(d => d.FindElement(By.LinkText("Add Patient")));

            addPatientBtn.Click();

            driver.FindElement(By.Id("firstName")).SendKeys("Niamh");
            driver.FindElement(By.Id("lastName")).SendKeys("Kennedy");
            driver.FindElement(By.Id("phone")).SendKeys("0871324567");
            driver.FindElement(By.Id("email")).SendKeys("louise.crowe7@gmail.com");
            driver.FindElement(By.Id("address")).SendKeys("1 Greentrees Road");
            driver.FindElement(By.Id("dateOfBirth")).SendKeys("23041974");
            driver.FindElement(By.Id("medications")).SendKeys("None very healthy");
            // select gender from dropdown list
            IWebElement genderField = driver.FindElement(By.Id("gender"));

            SelectElement gender = new (genderField);

            gender.SelectByValue("Female");

            // select therapist from dropdown list
            IWebElement therapistField = driver.FindElement(By.Id("therapist"));

            SelectElement therapistName = new (therapistField);

            therapistName.SelectByText("Dylan Crowe");

            // save patient - click save button
            driver.FindElement(By.ClassName("edit-btn")).Click();

            // Search for newly created patient
            // return to patient list - click Patients Link in NavBar
            IWebElement patientsLink =
                wait.Until(d => d.FindElement(By.LinkText("Patients")));

            patientsLink.Click();

            // search for new patient
            IWebElement searchField =
                wait.Until(d => d.FindElement(By.ClassName("form-control")));

            searchField.SendKeys("Niamh Kennedy");

            // click Search Button
            IWebElement searchButton =
                wait.Until(d => d.FindElement(By.ClassName("btn-primary")));

            searchButton.Click();

            // give time for search results to load
            TestHelper.Pause(3000);

            // check details on patientOverview page
            Assert.AreEqual("Niamh", driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/table/tbody/tr/td[1]")).Text);
            Assert.AreEqual("Kennedy", driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/table/tbody/tr/td[2]")).Text);

            // go to patient details page and check details match
            // click info button
            IWebElement patientInfoButton =
                wait.Until(d => d.FindElement(By.ClassName("fa-info-circle")));

            patientInfoButton.Click();

            // to give page time to load
            TestHelper.Pause(2000);

            Assert.AreEqual("Niamh Kennedy", driver.FindElement(By.Id("PatientName")).Text);
            Assert.AreEqual("0871324567", driver.FindElement(By.Id("Phone")).Text);
            Assert.AreEqual("louise.crowe7@gmail.com", driver.FindElement(By.Id("Email")).Text);
            Assert.AreEqual("1 Greentrees Road", driver.FindElement(By.Id("Address")).Text);
            Assert.AreEqual("23/4/1974", driver.FindElement(By.Id("DateOfBirth")).Text);
            Assert.AreEqual("Female", driver.FindElement(By.Id("Gender")).Text);
            Assert.AreEqual("Dylan Crowe", driver.FindElement(By.Id("TherapistName")).Text);
        }

        [TestMethod]
        public void AddingDuplicatePatient()
        {
            using IWebDriver driver = new ChromeDriver();
            //Explicit waits
            WebDriverWait wait = new (driver, TimeSpan.FromSeconds(10));

            // Log into application
            driver.Navigate().GoToUrl(HomeUrl);

            // can use prebuilt conditions
            IWebElement loginButton1 =
                wait.Until(d => d.FindElement(By.LinkText("Log in")));

            loginButton1.Click();

            IWebElement email =
                wait.Until(d => d.FindElement(By.Id("Input_Email")));

            email.SendKeys("louise.crowe7@gmail.com");

            IWebElement password =
                wait.Until(d => d.FindElement(By.Id("Input_Password")));

            password.SendKeys("Manutd77*");

            IWebElement loginButton2 =
                wait.Until(d => d.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[5]/button")));

            loginButton2.Click();

            // add patient

            IWebElement addPatientBtn =
            wait.Until(d => d.FindElement(By.LinkText("Add Patient")));

            addPatientBtn.Click();

            driver.FindElement(By.Id("firstName")).SendKeys("Louise");
            driver.FindElement(By.Id("lastName")).SendKeys("Murphy");

            // save patient - click save button
            driver.FindElement(By.ClassName("edit-btn")).Click();

            IWebElement duplicateError = wait.Until(d => d.FindElement(By.ClassName("alert-danger")));

            string duplicateErrorText = duplicateError.Text;

            Assert.AreEqual(duplicatePatientError, duplicateErrorText);            
        }
        
        
        [TestMethod]
        public void AddPatientValidation()
        {
            using IWebDriver driver = new ChromeDriver();
            // constants for testing validation
            string invalidPhone = "abd";
            string invalidEmail = "email.ie";


            //Explicit waits
            WebDriverWait wait = new (driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl(HomeUrl);

            IWebElement loginButton1 =
                wait.Until(d => d.FindElement(By.LinkText("Log in")));

            loginButton1.Click();

            IWebElement email =
                wait.Until(d => d.FindElement(By.Id("Input_Email")));

            email.SendKeys("louise.crowe7@gmail.com");

            IWebElement password =
                wait.Until(d => d.FindElement(By.Id("Input_Password")));

            password.SendKeys("Manutd77*");

            IWebElement loginButton2 =
                wait.Until(d => d.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[5]/button")));

            loginButton2.Click();

            IWebElement addPatientBtn =
                wait.Until(d => d.FindElement(By.LinkText("Add Patient")));

            addPatientBtn.Click();

            // don't input a First Name
            // don't input a Last Name
            driver.FindElement(By.Id("phone")).SendKeys(invalidPhone);
            driver.FindElement(By.Id("email")).SendKeys(invalidEmail);
            driver.FindElement(By.Id("address")).SendKeys("1 Greentrees Road");
            driver.FindElement(By.Id("dateOfBirth")).SendKeys("23041974");
            driver.FindElement(By.Id("medications")).SendKeys("None very healthy");
            // select gender from dropdown list
            IWebElement genderField = driver.FindElement(By.Id("gender"));

            SelectElement gender = new (genderField);

            gender.SelectByValue("Female");

            // select therapist from dropdown list
            IWebElement therapistField = driver.FindElement(By.Id("therapist"));

            SelectElement therapistName = new (therapistField);

            therapistName.SelectByText("Dylan Crowe");

            // try to submit form to save - click save button
            driver.FindElement(By.ClassName("edit-btn")).Click();

            // Validation Errors Should Display
            var validationErrors =
                driver.FindElements(By.ClassName("validation-message"));
            Assert.AreEqual(8, validationErrors.Count);             // 8 errors because errors appear twice
            Assert.AreEqual("The Phone field is not a valid phone number.", validationErrors[0].Text);
            Assert.AreEqual("The Email field is not a valid e-mail address.", validationErrors[1].Text);
            Assert.AreEqual("Please input patient's first name", validationErrors[2].Text);
            Assert.AreEqual("Please input patient's last name", validationErrors[3].Text);


            // fix errors
            driver.FindElement(By.Id("firstName")).SendKeys("Niamh");
            driver.FindElement(By.Id("lastName")).SendKeys("Kennedy");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("0871324567");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("louise.crowe7@gmail.com");


            TestHelper.Pause(6000);

            // try to submit form to save - click save button
            IWebElement saveButton = wait.Until(d => d.FindElement(By.ClassName("edit-btn")));

            saveButton.Click();

            // return to patient list - click Patients Link in NavBar
            IWebElement patientsLink =
                wait.Until(d => d.FindElement(By.LinkText("Patients")));

            patientsLink.Click();

            // search for new patient
            IWebElement searchField =
                wait.Until(d => d.FindElement(By.ClassName("form-control")));

            searchField.SendKeys("Niamh Kennedy");

            // click Search Button
            IWebElement searchButton =
                wait.Until(d => d.FindElement(By.ClassName("btn-primary")));

            searchButton.Click();

            // give time for search results to load
            TestHelper.Pause(3000);

            // check details on patientOverview page
            Assert.AreEqual("Niamh", driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/table/tbody/tr/td[1]")).Text);
            Assert.AreEqual("Kennedy", driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/table/tbody/tr/td[2]")).Text);

            // go to patient details page and check details match
            // click info button
            IWebElement patientInfoButton =
                wait.Until(d => d.FindElement(By.ClassName("fa-info-circle")));

            patientInfoButton.Click();

            // to give page time to load
            TestHelper.Pause(2000);

            Assert.AreEqual("Niamh Kennedy", driver.FindElement(By.Id("PatientName")).Text);
            Assert.AreEqual("0871324567", driver.FindElement(By.Id("Phone")).Text);
            Assert.AreEqual("louise.crowe7@gmail.com", driver.FindElement(By.Id("Email")).Text);
            Assert.AreEqual("1 Greentrees Road", driver.FindElement(By.Id("Address")).Text);
            Assert.AreEqual("23/4/1974", driver.FindElement(By.Id("DateOfBirth")).Text);
            Assert.AreEqual("Female", driver.FindElement(By.Id("Gender")).Text);
            Assert.AreEqual("Dylan Crowe", driver.FindElement(By.Id("TherapistName")).Text);            
        }
    }
}

