using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumTests
{
    public class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;
        private Dictionary<string, string> testUser = new Dictionary<string, string>();

        [SetUp]
        public void Setup()
        {
            testUser.Add("UserName", "testUser");
            testUser.Add("FirstName", "John");
            testUser.Add("LastName", "Doe");
            testUser.Add("Email", "j_doe@test.com");
            testUser.Add("Password", "aA1234*");
            testUser.Add("ConfirmPassword", "aA1234*");

            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://localhost:5001");
        }

        [Test]
        public void TestDoesNotShowPagesContentToUnauthorizedUsers()
        {
            driver.FindElement(By.LinkText("Profile")).Click();
            wait.Until(webDriver => webDriver.FindElement(By.Id("Unauthorized_View")).Displayed);
        }

        [Test]
        public void TestUserCanRegisterAndLogIn()
        {
            driver.FindElement(By.LinkText("Register")).Click();

            string testUserParamValue;
            foreach(string key in testUser.Keys)
            {
                if (testUser.TryGetValue(key, out testUserParamValue))
                {
                    driver.FindElement(By.Id($"Input_{key}")).SendKeys(testUserParamValue);
                }
            }
            driver.FindElement(By.Id("Register_Button")).Click();

            driver.FindElement(By.LinkText("Click here to confirm your account")).Click();
            LogInAsATestUser();

            wait.Until(webDriver => webDriver.FindElement(By.LinkText("Hello, testUser!")).Displayed);
        }

        [Test]
        public void TestShowsPagesContentToAuthorizedUsers()
        {
            LogInAsATestUser();
            wait.Until(webDriver => webDriver.FindElement(By.LinkText("Profile")).Displayed);
            driver.FindElement(By.LinkText("Profile")).Click();

            wait.Until(webDriver => webDriver.FindElement(By.Id("UserName")).Displayed);
            driver.FindElement(By.Id("Full_Name"));
            driver.FindElement(By.Id("Email"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        private void LogInAsATestUser()
        {
            testUser.TryGetValue("UserName", out string testUserUserName);
            testUser.TryGetValue("Password", out string testUserPassword);

            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Input_UserName")).SendKeys(testUserUserName);
            driver.FindElement(By.Id("Input_Password")).SendKeys(testUserPassword);
            driver.FindElement(By.Id("Log_In_Button")).Click();
        }
    }
}