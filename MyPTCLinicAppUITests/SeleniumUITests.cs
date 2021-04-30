using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumUITests
{
    [TestClass]
    public class SeleniumUITests
    {
        
        [TestMethod]
        public void LoadApplication()
        {
            // 'using' used to ensure the dispose method gets called when we're finished
            // using the ChromeDriver instance, cleaning any unmanaged resources
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://myptclinicappapi.azurewebsites.net/");
                driver.Navigate().GoToUrl("https://myptclinicappapi.azurewebsites.net/");
                driver.Manage().Window.Size = new System.Drawing.Size(1296, 696);
                driver.FindElement(By.CssSelector(".btn")).Click();
                driver.FindElement(By.CssSelector(".btn")).Click();
                driver.FindElement(By.LinkText("Appointments")).Click();
                driver.FindElement(By.CssSelector(".k-scheduler-views > .k-button:nth-child(1) > .k-button-text")).Click();
                driver.FindElement(By.CssSelector(".k-button:nth-child(2) > .k-button-text")).Click();
                driver.FindElement(By.CssSelector(".k-button:nth-child(3) > .k-button-text")).Click();
                driver.FindElement(By.CssSelector(".k-button:nth-child(4) > .k-button-text")).Click();
                driver.FindElement(By.CssSelector(".k-button:nth-child(3) > .k-button-text")).Click();
                driver.FindElement(By.LinkText("Treatments")).Click();
            }
        }



//        private static TestContext testContext;
//        private RemoteWebDriver driver;

//        [ClassInitialize]
//        public static void Initialize(TestContext testContext)
//        {
//            SeleniumUITests.testContext = testContext;
//        }

//        [TestInitialize]
//        public void TestInit()
//        {
//            driver = GetChromeDriver();
//            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
//        }

//        [TestCleanup]
//        public void TestClean()
//        {
//            driver.Quit();
//        }


//        [TestMethod]
//        public void LaunchTherapistPage()
//        {
//            using (IWebDriver driver = new ChromeDriver())
//            {
//                //driver.Navigate().GoToUrl("https://localhost:5001/");
//                driver.Navigate().GoToUrl("https://www.google.com/");
            

//                //driver.FindElement(By.LinkText("Therapists")).Click();
//                //var pageSource = driver.PageSource;

//                //StringAssert.Contains(pageSource, "Dylan", "Dylan Crowe should be visible");

//            }


//            ////var webAppUrl = _testContext.Properties["webAppUrl"].ToString();

//            //var startTimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
//            //var endTimeStamp = startTimeStamp + 60 * 10;

//            ////Arrange
//            //string inputFirstName = "Emily";
//            //string inputLastName = "Lovely";
//            //string expectedResult = "";

//            ////Act
//            ////driver.Navigate().GoToUrl(webAppUrl);
//            //driver.Navigate().GoToUrl("https://localhost/5001/");

//        }

//        //[TestMethod]
//        //public void SampleFunctionalTest1()
//        //{
//        //    // reads in url
//        //    var webAppUrl = _testContext.Properties["webAppUrl"].ToString();

//        //    var startTimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
//        //    var endTimeStamp = startTimeStamp + 60 * 10;

//        //    //Arrange
//        //    string inputFirstName = "Emily";
//        //    string inputLastName = "Lovely";
//        //    string expectedResult = "";

//        //    //Act
//        //    driver.Navigate().GoToUrl("https://localhost/5001/");
//        //    driver.Manage().Window.Size = new System.Drawing.Size(1296, 696);
//        //    driver.FindElement(By.LinkText("Therapists")).Click();
//        //    var pageSource = driver.PageSource;

//        //    StringAssert.Contains(pageSource, "Dylan", "Dylan Crowe should be visible");
////    //driver.FindElement(By.CssSelector("div:nth-child(7) > .btn")).Click();
//        //    //driver.FindElement(By.Id("firstName")).Click();
//        //    //driver.FindElement(By.Id("firstName")).SendKeys("Emily");
//        //    //driver.FindElement(By.Id("lastName")).SendKeys("Lovely");
//        //    //driver.FindElement(By.CssSelector(".btn-primary")).Click();
//        //    //driver.FindElement(By.LinkText("Back to therapist list")).Click();
//        //    //driver.FindElement(By.CssSelector(".form-control")).Click();
//        //    //driver.FindElement(By.CssSelector(".form-control")).SendKeys("Emily Lovely");
//        //    //driver.FindElement(By.CssSelector(".input-group-append > .btn-primary")).Click();
//        //    //driver.FindElement(By.CssSelector(".fa-info-circle")).Click();
//        //    //driver.FindElement(By.CssSelector(".page-title")).Click();

//        //    //Assert
//        //}


//        // configuring the driver
//        private RemoteWebDriver GetChromeDriver()
//        {
//            var path = Environment.GetEnvironmentVariable("ChromeWebDriver");
//            var options = new ChromeOptions();
//            options.AddArguments("--no-sandbox");
//            options.AddArguments("headless");

//            if (!string.IsNullOrEmpty(path))
//            {
//                return new ChromeDriver(path, options, TimeSpan.FromSeconds(300));
//            }
//            else
//            {
//                return new ChromeDriver(options);
//            }

//        }
    }
}
