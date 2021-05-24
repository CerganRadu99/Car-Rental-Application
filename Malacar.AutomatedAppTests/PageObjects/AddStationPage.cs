using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Malacar.AutomatedAppTests.PageObjects
{
    class AddStationPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement stationName;

        [FindsBy(How = How.Id, Using = "NumberOfVehicles")]
        private IWebElement numberOfVehicles;

        [FindsBy(How = How.Id, Using = "NumberOfEmployees")]
        private IWebElement numberOfEmployees;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div[1]/div/div/form/div[4]/input")]
        private IWebElement createButton;

        public AddStationPage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Save(string stationName, string numberOfVehicles, string numberOfEmployees)
        {
            this.stationName.Clear();
            this.stationName.SendKeys(stationName);
            this.numberOfVehicles.Clear();
            this.numberOfVehicles.SendKeys(numberOfVehicles);
            this.numberOfEmployees.Clear();
            this.numberOfEmployees.SendKeys(numberOfEmployees);
            createButton.Click();
        }
    }
}
