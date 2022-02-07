using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using SeleniumBDDAuto.Tests.Models;
using SeleniumBDDAuto.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumBDDAuto.Tests.Steps
{
    [Binding]
    public class CartCheckoutSteps
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;
        public User user { get; private set; }
        public ShoppingCart shoppingCart { get; private set; }
        private int itemCount;
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public CartCheckoutSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I login with valid credentials")]
        public void GivenILoginWithValidCredentials()
        {
            Logger.Info("Login to the application");

            LoginPage loginPage = new LoginPage(_driver);
            loginPage.OpenLoginURL();

            user = new User();
            user.Username = "test_dona@gmail.com";
            user.Password = "Test1234";
            loginPage.EnterUsernameAndPassword(user);

            loginPage.LoginWithValidCredentials();

            DashboardPage dashboardPage = new DashboardPage(_driver);
            var actualText = dashboardPage.GetTextDisplayed();
            Assert.AreEqual(actualText, "My account", true);
        }
        
        [Given(@"I add an item - '(.*)' in the '(.*)' menu to shopping cart")]
        public void GivenIAddAnItem_InTheMenuToShoppingCart(int itemNumber, string menuName)
        {
            DashboardPage dashboardPage = new DashboardPage(_driver);
            dashboardPage.ClickMenu(menuName);
            var actualPageTitle = dashboardPage.GetPageTitleDisplayed();
            Assert.AreEqual(actualPageTitle, menuName, true);

            DressesPage dressesPage = new DressesPage(_driver);
            //Get Price
            string price = dressesPage.GetPrice(itemNumber);
            string priceAmt = (price).Trim('$');
            double pricevalue = Convert.ToDouble(priceAmt);
            _scenarioContext.Add("item _" + itemNumber + "_price", priceAmt);
            //Select Item
            dressesPage.ClickItem(itemNumber);
            

            SingleDressPage singleDressPage = new SingleDressPage(_driver);
            singleDressPage.ClickAddToCart();
            
            var expectedMessage = "Product successfully added to your shopping cart";
            var actualMessage = singleDressPage.GetAddToCartMessage();
            Assert.AreEqual(actualMessage, expectedMessage, true);
            
        }
        
        [Given(@"I click on Continue shopping button")]
        public void GivenIClickOnContinueShoppingButton()
        {
            
        }
        
        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            SingleDressPage singleDressPage = new SingleDressPage(_driver);
            singleDressPage.ClickCheckout();

            ShoppingCartSummaryPage shoppingCartSummaryPage = new ShoppingCartSummaryPage(_driver);
            shoppingCartSummaryPage.Checkout();
        }
        
        [Then(@"the product should be listed in the final checkout")]
        public void ThenTheProductShouldBeListedInTheFinalCheckout()
        {
            
        }
        
        [Then(@"the total price of the cart should be displayed")]
        public void ThenTheTotalPriceOfTheCartShouldBeDisplayed()
        {
            
        }
        
        [Then(@"products should be listed in the final checkout")]
        public void ThenProductsShouldBeListedInTheFinalCheckout()
        {
            
        }
    }
}
