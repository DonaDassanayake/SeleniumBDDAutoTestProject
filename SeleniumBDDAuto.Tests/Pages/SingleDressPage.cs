using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBDDAuto.Tests.Pages
{
    public class SingleDressPage
    {
        private IWebDriver _driver;
        protected IWebElement addToCartBtn => _driver.FindElement(By.XPath("//button[@type='submit']/*[text()='Add to cart']"));
        protected IWebElement messageLabel => _driver.FindElement(By.XPath("//div[@id='layer_cart']//i[@class='icon-ok']//parent::h2"));

        protected IWebElement continueShoppingBtn => _driver.FindElement(By.XPath("//*[@id='layer_cart']//span[@title='Continue shopping']"));
        protected IWebElement proceedToCheckoutBtn => _driver.FindElement(By.XPath("//*[@id='layer_cart']//*[@title='Proceed to checkout']"));

        public SingleDressPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void ClickAddToCart()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(addToCartBtn);            

            addToCartBtn.Click();

            Thread.Sleep(1000);
        }

        public string GetAddToCartMessage()
        {
            return messageLabel.Text;
        }
        public DressesPage ClickContinueShopping()
        {
            continueShoppingBtn.Click();
            return new DressesPage(_driver);
            //send driver to the previous page
        }
        public ShoppingCartSummaryPage ClickCheckout()
        {
            proceedToCheckoutBtn.Click();
            return new ShoppingCartSummaryPage(_driver);
        }

    }
}
