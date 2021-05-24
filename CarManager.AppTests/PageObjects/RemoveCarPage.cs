using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CarManager.AppTests.PageObjects
{
    class RemoveCarPage
    {
        IWebDriver webDriver;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/form/input[2]")]
        private IWebElement deleteButton;

        public RemoveCarPage(IWebDriver driver)
        {
            this.webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Delete()
        {
            deleteButton.Click();
        }
    }
}
