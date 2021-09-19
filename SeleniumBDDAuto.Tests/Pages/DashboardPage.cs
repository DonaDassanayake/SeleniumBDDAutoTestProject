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
        public string selectingMenu { get; set; }

        protected IWebElement actualText => _driver.FindElement(By.XPath("//*[@class='page-heading']"));
        protected IWebElement menuName => _driver.FindElement(By.XPath("//div[@id='block_top_menu']/ul/li/a[text()='" + selectingMenu + "']"));
        protected IWebElement pageTitle => _driver.FindElement(By.XPath("//h2[@class ='title_block']"));

        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string GetTextDisplayed()
        {
            return actualText.Text;
        }
        public void ClickMenu(string menu)
        {
            selectingMenu = menu;
            menuName.Click();
        }

        public string GetPageTitleDisplayed()
        {
            return pageTitle.Text;
        }
    }
}
