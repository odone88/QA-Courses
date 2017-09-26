using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.IO;
using System.Collections.Generic;

namespace QA_Courses
{
    [TestFixture]
    public class Task17
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestFromTaskSeventeen()
        {
            driver.Url = "http://localhost:8080/litecard/admin/login.php?redirect_url=%2Flitecard%2Fadmin%2F";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            driver.FindElement(By.XPath("//span[contains(text(),'Catalog')]")).Click();
            driver.FindElement(By.CssSelector("#doc-catalog > a > span")).Click();
            driver.FindElement(By.CssSelector("#content tr:nth-child(3) > td:nth-child(3) > a")).Click();
            IList<IWebElement> listOfProducts = driver.FindElements(By.PartialLinkText("Duck"));

            driver.FindElement(By.LinkText("Blue Duck")).Click();
            if (driver.Manage().Logs.GetLog("browser").Count != 0)
                Console.WriteLine(driver.Manage().Logs.GetLog("browser"));
            driver.FindElement(By.CssSelector("#content > form > p > span > button:nth-child(2)")).Click();

            driver.FindElement(By.LinkText("Green Duck")).Click();
            if (driver.Manage().Logs.GetLog("browser").Count != 0)
                Console.WriteLine(driver.Manage().Logs.GetLog("browser"));
            driver.FindElement(By.CssSelector("#content > form > p > span > button:nth-child(2)")).Click();
            driver.Manage().Logs.GetLog("browser");

            driver.FindElement(By.LinkText("Purple Duck")).Click();
            if (driver.Manage().Logs.GetLog("browser").Count != 0)
                Console.WriteLine(driver.Manage().Logs.GetLog("browser"));
            driver.FindElement(By.CssSelector("#content > form > p > span > button:nth-child(2)")).Click();

            driver.FindElement(By.LinkText("Red Duck")).Click();
            if (driver.Manage().Logs.GetLog("browser").Count != 0)
                Console.WriteLine(driver.Manage().Logs.GetLog("browser"));
            driver.FindElement(By.CssSelector("#content > form > p > span > button:nth-child(2)")).Click();

            driver.FindElement(By.LinkText("Yellow Duck")).Click();
            if (driver.Manage().Logs.GetLog("browser").Count != 0)
                Console.WriteLine(driver.Manage().Logs.GetLog("browser"));
            driver.FindElement(By.CssSelector("#content > form > p > span > button:nth-child(2)")).Click();

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
