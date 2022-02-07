using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDAuto.Tests.Pages
{
    public class ItemQucikViewPage
    {
        private IWebDriver _driver;

        //Locate elements
        private IWebElement addToCartBtn => _driver.FindElement(By.Name("Submit"));
        private IWebElement proceedToCheckout => _driver.FindElement(By.XPath("//a[@title='Proceed to checkout']"));

        //Elements in the Summary page
        private IWebElement finalAmount => _driver.FindElement(By.XPath("//td[@class='cart_total']//span[@class='price']"));



        public ItemQucikViewPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickAddToCartBtn()
        {
            //Click "Add to cart" button
            addToCartBtn.Click();
        }

        public void ClickProceedToCheckout()
        {
            proceedToCheckout.Click();
        }

        public string GetFinalAmount()
        {
            return finalAmount.Text; ;
        }


    }
}
