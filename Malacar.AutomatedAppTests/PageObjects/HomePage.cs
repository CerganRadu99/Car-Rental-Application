using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Malacar.AutomatedAppTests.PageObjects
{
    class HomePage
    {
        private IWebDriver webDriver;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Login")]
        private IWebElement loginButton;

        public LoginPage GoToLoginPage()
        {
            loginButton.Click();
            return new LoginPage(webDriver);
        }

        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44335/");
        }
    }
}
