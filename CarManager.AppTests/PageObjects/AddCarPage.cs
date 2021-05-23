using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CarManager.AppTests.PageObjects
{
    class AddCarPage
    {
        private IWebDriver webDriver;

        [FindsBy(How=How.Id, Using = "Plate")]
        private IWebElement carPlateNumber;

        [FindsBy(How = How.Id, Using = "Class")]
        private IWebElement carClass;

        [FindsBy(How = How.Id, Using = "Color")]
        private IWebElement carColor;

        [FindsBy(How = How.Id, Using = "Seats")]
        private IWebElement seatNumber;

        [FindsBy(How = How.Id, Using = "SelectedStation")]
        private IWebElement carStation;

        [FindsBy(How = How.Id, Using = "Photo")]
        private IWebElement carPath;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/form/div[3]/input")]
        private IWebElement saveButton;

        public AddCarPage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Save(string carPlateNumber, string carClass, string carColor,
            int seatNumber, string carStation)
        {
            this.carPlateNumber.Clear();
            this.carPlateNumber.SendKeys(carPlateNumber);

            this.carClass.Clear();
            this.carClass.SendKeys(carClass);

            this.carColor.Clear();
            this.carColor.SendKeys(carColor);

            this.seatNumber.Clear();
            string seats = seatNumber.ToString();
            this.seatNumber.SendKeys(seats);

           

            saveButton.Click();

        }
    }
}
