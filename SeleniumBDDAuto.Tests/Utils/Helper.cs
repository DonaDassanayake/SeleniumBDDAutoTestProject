using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDAuto.Tests.Utils
{
    public static class Helper
    {
        //protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static IWebElement WaitUntilElementVisible(IWebDriver driver, By elementLocator, int timeout = 20)
        {
            try
            {
               // logger.Info("Hello ", "Earth");
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                Console.WriteLine("Element with the locator : '" + elementLocator + "' is visible");
                Debug.WriteLine("Element with the locator : '" + elementLocator + "' is visible");
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
                
            }
            catch(NoSuchElementException ex)
            {
                Debug.WriteLine("Element with the locator : '"+elementLocator+"' was not found");
               // logger.Error(ex, "Something bad happened");
                throw ex;
            }
        }
    }
}
