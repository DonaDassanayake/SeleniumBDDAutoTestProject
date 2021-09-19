using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDAuto.Tests.Pages
{
    public class ShoppingCartSummaryPage
    {
        private IWebDriver _driver;

        protected IWebElement checoutBtnInSummary => _driver.FindElement(By.XPath("//a[@class='button btn btn-default standard-checkout button-medium']"));
        protected IWebElement checoutBtnInAddress => _driver.FindElement(By.XPath("//button[@class='button btn btn-default button-medium']"));
        protected IWebElement agreeCheckBoxInShipping => _driver.FindElement(By.XPath("//input[@type='checkbox' and @id='cgv']"));
        protected IWebElement checkoutBtnInShipping => _driver.FindElement(By.XPath("//button[@name='processCarrier']"));
        protected IWebElement payByWireLink => _driver.FindElement(By.XPath("//a[@class='bankwire']"));
        protected IWebElement confirmOrderBtn => _driver.FindElement(By.XPath("//button/span[text()='I confirm my order']"));

        public ShoppingCartSummaryPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void Checkout()
        {
            checoutBtnInSummary.Click();
            checoutBtnInAddress.Click();
            agreeCheckBoxInShipping.Click();
            checkoutBtnInShipping.Click();
            payByWireLink.Click();
            confirmOrderBtn.Click();
        }

       
    }
}
