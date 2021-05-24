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

        public RemoveCarPage GotoRemoveCarPage()
        {
            var elements = carIndexList.FindElements(By.TagName("tr"));
            var nr = elements.Count();
            carIndexList.FindElement(By.XPath("/html/body/div/main/div/table/tbody/tr[" + (nr - 1) + "]/td[7]/a[3]")).Click();
            return new RemoveCarPage(webDriver);
        }

        public bool CheckCarWasDeleted(string carPlate)
        {
            //var trs = carForDeleteIndex.FindElements(By.TagName("tr"));
            ////var tds = carForDeleteIndex.FindElements(By.TagName("td"));
            ////IWebElement originalTd = (IWebElement)tds.Where(element => element.Text.Equals(carPlate));
            //IWebElement originalTr = (IWebElement)trs.Where(element => element.Text.Equals(carPlate));
            //originalTr.FindElement(By.XPath("td[6]")).Click();

            //carForDeleteIndex.FindElement(By.XPath("//div/table/tbody/tr[contains(text(),'DJ60BQN')/td[contains(@class,'randomClassOver')]/a[3]")).Click();
            var elements = carIndexList.FindElements(By.TagName("td"));
            return elements.Where(element => element.Text.Equals(carPlate)).Count() == 0;


        }

        public bool CarExists(string carPlate)
        {
            var elements = carIndexList.FindElements(By.TagName("td"));
            return elements.Where(element => element.Text.Equals(carPlate)).Count() > 0;
        }

        ///html/body/div/main/div/table/tbody/tr[2]/td[7]/a[3]
    }
}
