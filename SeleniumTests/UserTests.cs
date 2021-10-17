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
        private Dictionary<string, string> testUserFixture = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void SetUpTheFixture()
        {
            testUserFixture.Add("UserName", "testUser");
            testUserFixture.Add("FirstName", "John");
            testUserFixture.Add("LastName", "Doe");
            testUserFixture.Add("Email", "j_doe@test.com");
            testUserFixture.Add("Password", "aA1234*");
            testUserFixture.Add("ConfirmPassword", "aA1234*");
        }

        [SetUp]
        public void Setup()
        {
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
            foreach(string key in testUserFixture.Keys)
            {
                if (testUserFixture.TryGetValue(key, out testUserParamValue))
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
            testUserFixture.TryGetValue("UserName", out string testUserUserName);
            testUserFixture.TryGetValue("Password", out string testUserPassword);

            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Input_UserName")).SendKeys(testUserUserName);
            driver.FindElement(By.Id("Input_Password")).SendKeys(testUserPassword);
            driver.FindElement(By.Id("Log_In_Button")).Click();
        }
    }
}