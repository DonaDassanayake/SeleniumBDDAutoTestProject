using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBDDAuto.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumBDDAuto.Tests.Steps
{
    [Binding]
    public class ShoppingCartSteps
    {
        private IWebDriver _driver = new ChromeDriver();

        [Given(@"I open the website")]
        public void GivenIOpenTheWebsite()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }
        
        [Given(@"then the homepage should be displayed")]
        public void GivenThenTheHomepageShouldBeDisplayed()
        {
            HomePage homepage = new HomePage(_driver);
            bool isHomepageDisplayed = homepage.IsLogoDisplayed();

            Assert.IsTrue(isHomepageDisplayed); 
        }
        
        [When(@"I add item to cart and proceed to checkout")]
        public void WhenIAddItemToCartAndProceedToCheckout()
        {
            HomePage homepage = new HomePage(_driver);
            homepage.ClickFirstItem();

            //Improvement
            //Add a step to capture the price at first page and add to scenarioContext


            _driver.SwitchTo().Frame(_driver.FindElement(By.ClassName("fancybox-iframe")));

            ItemQucikViewPage itemQucikViewPage = new ItemQucikViewPage(_driver);
            itemQucikViewPage.ClickAddToCartBtn();
            itemQucikViewPage.ClickProceedToCheckout();
            //ScenarioContext.Current.Pending();


        }
        
        [Then(@"the item should be added to the cart")]
        public void ThenTheItemShouldBeAddedToTheCart()
        {
           //Add code to make sure the item is visible on this page
        }       
        
        [Then(@"the item total should be displayed as '(.*)'")]
        public void ThenTheItemTotalShouldBeDisplayedAs(string expectedText)
        {
            ItemQucikViewPage itemQucikViewPage = new ItemQucikViewPage(_driver);
            string actualText = itemQucikViewPage.GetFinalAmount();

            Assert.AreEqual(actualText, expectedText, true);
        }

    }
}
