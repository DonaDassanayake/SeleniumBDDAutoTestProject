using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Allure.Commons;
using NLog;
using NUnit.Framework;
using System.IO;
using System.Diagnostics;

namespace SeleniumBDDAuto.Tests.Hooks
{
    [Binding]
    public class GeneralHooks
    {
        private ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private AllureLifecycle _allureLifecycle;
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public GeneralHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _allureLifecycle = AllureLifecycle.Instance;
        }

        [OneTimeSetUp]
        public void SetupForAllure()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        }

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Maximize();

            _scenarioContext.Add("currentDriver", _driver);
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
            Logger.Info("WebDriver termination.");
            _driver.Quit();

            // AllureHackForScenarioOutlineTests();
            NLog.LogManager.Shutdown();
        }

        [AfterTestRun]
        public static void AfterTests()
        {
            CloseChromeDriverProcesses();
        }

        private static void CloseChromeDriverProcesses()
        {
            var chromeDriverProcesses = Process.GetProcesses().
                Where(pr => pr.ProcessName == "chromedriver");

            if (chromeDriverProcesses.Count() == 0)
            {
                return;
            }

            foreach (var process in chromeDriverProcesses)
            {
                process.Kill();
            }
        }

        private void AllureHackForScenarioOutlineTests()
        {
            _scenarioContext.TryGetValue(out TestResult testresult);
            _allureLifecycle.UpdateTestCase(testresult.uuid, tc =>
            {
                tc.name = _scenarioContext.ScenarioInfo.Title;
                tc.historyId = Guid.NewGuid().ToString();
            });
        }
    }
}
