using CarManager.AppTests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CarManager.AppTests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver webDriver;

        [TestInitialize]
        public void Initialize()
        {
            webDriver = new ChromeDriver();
        }
        [TestMethod]
        public void TestMethod1()
        {
            //driver.Navigate().GoToUrl("https://localhost:44335/");
            //IWebElement loginPageLink = driver.FindElement(By.LinkText("Login"));
            //loginPageLink.Click();

            //var emailTextBox= driver.FindElement(By.Id("Input_Email"));
            //var passwordTextBox = driver.FindElement(By.Id("Input_Password"));
            //var loginButton = driver.FindElement(By.XPath("/html/body/div/main/div/div/section/form/div[5]/button"));

            //emailTextBox.SendKeys("admin@gmail.com");
            //passwordTextBox.SendKeys("Abc123!");
            //loginButton.Click();

            Random randomCarPlate = new Random();
            var firstL = Convert.ToChar(randomCarPlate.Next(65, 90));
            var secondL = Convert.ToChar(randomCarPlate.Next(65, 90));
            var thirdL = Convert.ToChar(randomCarPlate.Next(65, 90));
            string carPlate = "DJ" + randomCarPlate.Next(10, 99) + firstL + secondL + thirdL;

            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("admin@gmail.com", "Abc123!");

            CarsIndexPage indexPage = new CarsIndexPage(webDriver);
            indexPage.GoToPage();
            AddCarPage addCarPage = indexPage.GotoAddCarPage();
            addCarPage.Save(carPlate, "Compact", "Blue", 5, "Sibiu");
           
            Assert.IsTrue(indexPage.CarExists(carPlate));
        }

        [TestCleanup]
        public void Cleanup()
        {
            webDriver.Close();
        }
    }
}
