using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Malacar.AutomatedAppTests.PageObjects
{
    class LoginPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "Input_Email")]
        private IWebElement userNameTextBox;

        [FindsBy(How = How.Id, Using = "Input_Password")]
        private IWebElement passwordTextBox;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/section/form/div[5]/button")]
        private IWebElement loginButton;

        public LoginPage(IWebDriver driver)
        {
            webDriver = driver;
            SeleniumExtras.PageObjects.PageFactory.InitElements(driver, this);
        }

        public void Login(string userName, string password)
        {
            userNameTextBox.Clear();
            userNameTextBox.SendKeys(userName);
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(password);
            loginButton.Click();
        }
    }
}
