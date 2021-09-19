using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace SeleniumBDDAuto.Tests.Pages
{
    public class DressesPage
    {
        private IWebDriver _driver;
        
        public int itemNumber { get; set; }

        protected IWebElement item => _driver.FindElement(By.XPath("//ul[@class='product_list grid row']/li["+itemNumber+"]//div[@class='right-block']"));
        protected IWebElement moreBtn => _driver.FindElement(By.XPath("//ul[@class='product_list grid row']/li["+itemNumber+"]//a[@class='button lnk_view btn btn-default']"));
        protected IWebElement itemPrice => _driver.FindElement(By.XPath("//ul[@class='product_list grid row']/li["+itemNumber+"]//div[2]/div[@itemprop='offers']/span[@itemprop='price']"));

        public DressesPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        
        public void ClickItem(int number)
        {
            itemNumber = number;

            //to perform Scroll on application using Selenium
            Actions actions = new Actions(_driver);
            actions.MoveToElement(item);
            actions.MoveToElement(item).Perform();
            
            moreBtn.Click();
           
           // return new SingleDressPage(_driver);
        }

        public string GetPrice(int number)
        {
            itemNumber = number;
            return itemPrice.Text;
        }
    }
}
