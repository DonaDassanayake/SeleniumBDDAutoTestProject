using System;
using TechTalk.SpecFlow;

namespace SeleniumBDDAuto.Tests.Steps
{
    [Binding]
    public class CartCheckoutSteps
    {
        [Given(@"I login with valid credentials")]
        public void GivenILoginWithValidCredentials()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I add an item - '(.*)' in the '(.*)' menu to shopping cart")]
        public void GivenIAddAnItem_InTheMenuToShoppingCart(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I click on Continue shopping button")]
        public void GivenIClickOnContinueShoppingButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the product should be listed in the final checkout")]
        public void ThenTheProductShouldBeListedInTheFinalCheckout()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the total price of the cart should be displayed")]
        public void ThenTheTotalPriceOfTheCartShouldBeDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"products should be listed in the final checkout")]
        public void ThenProductsShouldBeListedInTheFinalCheckout()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
