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
    public class Task8
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
        public void TestFromTaskEight()
        {
            driver.Url = "http://localhost/litecard/public_html/en/";
            var ListOfStickers = driver.FindElements(By.ClassName("sticker"));
            var ListOfArticleImages = driver.FindElements(By.XPath("//*[@class= 'manufacturer']"));

            Assert.AreEqual(ListOfArticleImages.Count, ListOfStickers.Count, "Not all ducks have only one sticker.");
            
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
