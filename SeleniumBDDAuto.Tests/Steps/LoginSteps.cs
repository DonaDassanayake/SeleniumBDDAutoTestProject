using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumBDDAuto.Tests.Models;
using SeleniumBDDAuto.Tests.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumBDDAuto.Tests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;

        public User user { get; private set; }
        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I navigate to the Login Page")]
        public void GivenINavigateToTheLoginPage()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.OpenLoginURL();
        }        
       
        [Given(@"I enter username '(.*)' and password '(.*)'")]
        public void GivenIEnterUsernameAndPassword(string username, string password)
        {
            LoginPage loginPage = new LoginPage(_driver);

            user = new User();
            user.Username = username;
            user.Password = password;

            loginPage.EnterUsernameAndPassword(user);
        }

        [When(@"I click on the Login button with valid credentials")]
        public void WhenIClickOnTheLoginButtonWithValidCredentials()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.LoginWithValidCredentials();
        }

        [When(@"I click on the Login button with Invalid credentials")]
        public void WhenIClickOnTheLoginButtonWithInvalidCredentials()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.LoginWithInvalidCredentials();
        }

        [Then(@"'(.*)' should be seen on the page")]
        public void ThenShouldBeSeenOnThePage(string expectedText)
        {
            DashboardPage dashboardPage = new DashboardPage(_driver);
            var actualText = dashboardPage.GetTextDisplayed();
            Assert.AreEqual(actualText, expectedText, true);
        }

        [Then(@"I should see an error message '(.*)' on the Login page")]
        public void ThenIShouldSeeAnErrorMessageOnTheLoginPage(string errorMessage)
        {
            LoginPage loginPage = new LoginPage(_driver);
            var errorText = loginPage.GetErrorDisplayed();
            Assert.AreEqual(errorText, errorMessage, true);
        }

    }
}
