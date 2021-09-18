﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumBDDAuto.Tests.Models;
using SeleniumBDDAuto.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDAuto.Tests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        protected IWebElement usernameTxtBox => _driver.FindElement(By.Id("email"));
        protected IWebElement passwordTxtBox => _driver.FindElement(By.Id("passwd"));
        protected IWebElement loginBtn => _driver.FindElement(By.Id("SubmitLogin"));

        protected IWebElement error => _driver.FindElement(By.XPath("//div[@class='alert alert-danger']//li"));
       

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void OpenLoginURL()
        {
            _driver.Navigate().GoToUrl(Resources.SiteUrl);
        }

        public void EnterUsernameAndPassword(User user)
        {
            usernameTxtBox.SendKeys(user.Username);
            passwordTxtBox.SendKeys(user.Password);
        }        

        public DashboardPage LoginWithValidCredentials()
        {    
            loginBtn.Click();
            return new DashboardPage(_driver);
        }

        public void LoginWithInvalidCredentials()
        {           
            loginBtn.Click();
            this.GetErrorDisplayed();
        }

        public string GetErrorDisplayed()
        {
            return error.Text;
        }

    }
}
