using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDAuto.Tests.Pages
{
    public class DashboardPage
    {
        private IWebDriver _driver;
        protected IWebElement actualText => _driver.FindElement(By.XPath("//*[@class='page-heading']"));
        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string GetTextDisplayed()
        {
            return actualText.Text;
        }
    }
}
