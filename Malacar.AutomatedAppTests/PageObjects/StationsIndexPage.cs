using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;


namespace Malacar.AutomatedAppTests.PageObjects
{
    class StationsIndexPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using = "main")]
        private IWebElement stationsList;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/p/a")]
        private IWebElement addStationButton;

        public StationsIndexPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44335/Stations");
        }

        public AddStationPage GoToAddStationPage()
        {
            addStationButton.Click();
            return new AddStationPage(webDriver);
        }

        public DeleteStationPage GoToDeleteStationPage()
        {
            var elements = stationsList.FindElements(By.TagName("tr"));
            var nr = elements.Count();
            stationsList.FindElement(By.XPath("/html/body/div/main/div/table/tbody/tr[" + (nr - 1) + "]/td[4]/a[3]")).Click();
            return new DeleteStationPage(webDriver);
        }

        public bool StationExists(string stationName)
        {
            var elements = stationsList.FindElements(By.TagName("td"));
            return elements.Where(element => element.Text.Equals(stationName)).Count() > 0;
        }

        public bool CheckIfStationIsPresent(string stationName)
        {
            var elements = stationsList.FindElements(By.TagName("td"));
            return elements.Where(element => element.Text.Equals(stationName)).Count() == 0;
        }
    }
}
