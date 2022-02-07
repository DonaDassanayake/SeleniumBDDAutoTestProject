using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDAuto.Tests.Pages
{
    public class HomePage
    {
        private IWebDriver _driver;

        //Finding elements
        private IWebElement logo => _driver.FindElement(By.Id("header_logo"));
        private IWebElement firstItem => _driver.FindElement(By.XPath("//ul[@id='homefeatured']/li[1]/div"));
        private IWebElement firstItemQuickviewBtn => _driver.FindElement(By.XPath("//ul[@id='homefeatured']/li[1]/div//a[@class='quick-view']"));
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsLogoDisplayed()
        {
            if(logo.Displayed)
            {
                return true;
            }

            return false;
        }

        public void ClickFirstItem()
        {
            //Scroll down to the first element
            ScrollDownToItem();

            //Click on the "Quick view" button displays in the item
            firstItemQuickviewBtn.Click();
        }

        public void ScrollDownToItem()
        {            
            Actions actions = new Actions(_driver);
            actions.MoveToElement(firstItem);
            actions.Perform();
        }
    }
}
