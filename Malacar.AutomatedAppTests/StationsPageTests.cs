using Malacar.AutomatedAppTests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Malacar.AutomatedAppTests
{
    [TestClass]
    public class StationsPageTests
    {
        private IWebDriver webDriver;

        [TestInitialize]
        public void Initialize()
        {
            webDriver = new ChromeDriver();
        }

        [TestMethod]
        public void StationsAddStation_Creates_StationWithGivenName()
        {
            Random randomNumber = new Random();
            string stationName = "MyTestStation " + randomNumber.Next(100, 10000000);
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("admin@gmail.com", "Abc123!");

            StationsIndexPage indexPage = new StationsIndexPage(webDriver);
            indexPage.GoToPage();
            AddStationPage addStationPage = indexPage.GoToAddStationPage();
            addStationPage.Save(stationName, "12", "133");


            Assert.IsTrue(indexPage.StationExists(stationName));

        }

        [TestMethod]
        public void StationsDeleteStation_Deletes_StationWithGivenName()
        {
            Random randomNumber = new Random();
            string stationName = "MyTestStation " + randomNumber.Next(100, 10000000);
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("admin@gmail.com", "Abc123!");

            StationsIndexPage indexPage = new StationsIndexPage(webDriver);
            indexPage.GoToPage();
            AddStationPage addStationPage = indexPage.GoToAddStationPage();
            addStationPage.Save(stationName, "12", "133");

            DeleteStationPage deleteStationPage = indexPage.GoToDeleteStationPage();
            deleteStationPage.Delete();

            Assert.IsTrue(indexPage.CheckIfStationIsPresent(stationName));

        }

        [TestCleanup]
        public void Cleanup()
        {
            webDriver.Close();
        }
    }
}
