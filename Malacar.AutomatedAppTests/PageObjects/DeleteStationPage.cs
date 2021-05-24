using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Malacar.AutomatedAppTests.PageObjects
{
    class DeleteStationPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/form/input[2]")]
        private IWebElement deleteButton;
        public DeleteStationPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        public void Delete()
        {
            deleteButton.Click();
        }

    }
}
