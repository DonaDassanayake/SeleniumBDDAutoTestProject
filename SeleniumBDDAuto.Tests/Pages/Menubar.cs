using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDAuto.Tests.Pages
{
    public class Menubar
    {
        private readonly IWebDriver _driver;
        private string selectingT;
        private IWebElement tshirt => _driver.FindElement(By.XPath("//div[@id='block_top_menu']/ul/li/a[text()='" + selectingT + "']"));


        public Menubar(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        //-------------Way 01 - Locate Elements--------------------------------------//
        //Property of the 'Dresses' menu element
        protected IWebElement dresses { get; set; }
        
        //Method to check Dresses menu is displayed
        public bool IsDressesMenuItemDisplayed(string selectingDresses)
        {
            dresses = _driver.FindElement(By.XPath("//div[@id='block_top_menu']/ul/li/a[text()='" + selectingDresses + "']"));
            return dresses.Displayed;
        }
        //-----------------------------------------------------------------------------//


        //--------------Way 02 - Locate Elements--------------------------------------//
        public bool IsTshirtsMenuItemDisplayed(string selectingT)
        {
            this.selectingT = selectingT;
            return this.tshirt.Displayed;
        }
        

    }
}
