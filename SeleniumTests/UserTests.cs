using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestUserCanRegisterAndLogIn()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Navigate().GoToUrl("https://localhost:5001");
                driver.FindElement(By.LinkText("Register")).Click();

                driver.FindElement(By.Id("Input_UserName")).SendKeys("testUser");
                driver.FindElement(By.Id("Input_FirstName")).SendKeys("John");
                driver.FindElement(By.Id("Input_LastName")).SendKeys("Doe");
                driver.FindElement(By.Id("Input_Email")).SendKeys("j_doe@test.com");
                driver.FindElement(By.Id("Input_Password")).SendKeys("aA1234*");
                driver.FindElement(By.Id("Input_ConfirmPassword")).SendKeys("aA1234*");
                driver.FindElement(By.ClassName("btn-primary")).Click();

                driver.FindElement(By.LinkText("Click here to confirm your account")).Click();
                driver.FindElement(By.LinkText("Login")).Click();
                driver.FindElement(By.Id("Input_UserName")).SendKeys("testUser");
                driver.FindElement(By.Id("Input_Password")).SendKeys("aA1234*");
                driver.FindElement(By.ClassName("btn-primary")).Click();

                wait.Until(webDriver => webDriver.FindElement(By.LinkText("Hello, testUser!")).Displayed);
            }
        }
    }
}