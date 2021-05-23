using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManager.AppTests.PageObjects
{
    class CarsIndexPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "main")]
        private IWebElement carIndexList;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/p/a")]
        private IWebElement addCarButton;

        public CarsIndexPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44335/Cars");
        }

        public AddCarPage GotoAddCarPage()
        {
            addCarButton.Click();
            return new AddCarPage(webDriver);
        }

        public bool CarExists(string carPlate)
        {
            var elements = carIndexList.FindElements(By.TagName("td"));
            return elements.Where(element => element.Text.Equals(carPlate)).Count() > 0;
        }

        
    }
}
