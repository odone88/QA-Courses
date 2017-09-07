using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.IO;

namespace QA_Courses
{
    [TestFixture]
    public class Task7
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
        public void TestFromTaskSeven()
        {
            driver.Url = "http://localhost/litecard/public_html/admin/login.php?redirect_url=%2Flitecard%2Fpublic_html%2Fadmin%2F";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            
            driver.FindElement(By.XPath("//span[contains(text(),'Appearence')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Logotype')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Catalog')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Product Groups')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Option Groups')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Manufacturers')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Suppliers')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Delivery Statuses')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Sold Out Statuses')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Quantity Units')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'CSV Import/Export')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Countries')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Currencies')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Customers')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'CSV Import/Export')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Newsletter')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Geo Zones')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Languages')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Storage Encoding')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");            
            driver.FindElement(By.XPath("//span[contains(text(),'Modules')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Background Jobs')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            
            driver.FindElement(By.XPath("//*[text()='Customer']")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");

            driver.FindElement(By.XPath("//span[contains(text(),'Shipping')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Payment')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Order Total')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Order Success')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Order Action')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Orders')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Order Statuses')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Pages')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Reports')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Settings')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Defaults')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'General')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Listings')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Images')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Checkout')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Advanced')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Security')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Slides')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Tax')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Tax Rates')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Translations')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'Users')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");
            driver.FindElement(By.XPath("//span[contains(text(),'vQmods')]")).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("h1")).Displayed, "Header is not displayed. Something is wrong.");


        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
