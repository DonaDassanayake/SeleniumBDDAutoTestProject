using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumBDDAuto.Tests.Hooks
{
    [Binding]
    public class GeneralHooks
    {
        private ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public GeneralHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();

            _scenarioContext.Add("currentDriver", _driver);
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
            _driver.Quit();
        }
    }
}
