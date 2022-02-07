using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDAuto.Tests.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
