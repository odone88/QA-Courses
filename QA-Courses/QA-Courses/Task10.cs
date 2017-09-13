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
    public class Task10
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
        public void TestFromTaskTen()
        {
            driver.Url = "http://localhost/litecard/public_html/en/";
            var duckInCampaign = driver.FindElement(By.CssSelector("#box-campaigns > div > ul > li > a.link > div.image-wrapper > img"));
            var nameOfTheDuck = duckInCampaign.GetAttribute("alt");
            var campaignPrice = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price")).Text;
            var regularPrice = driver.FindElement(By.CssSelector("#box-campaigns .regular-price")).Text;

            var campaignPriceColor = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price")).GetCssValue("color");
            var regularPriceColor = driver.FindElement(By.CssSelector("#box-campaigns .regular-price")).GetCssValue("color");
            var regularPriceStyle = driver.FindElement(By.CssSelector("#box-campaigns .regular-price")).GetCssValue("text-decoration");
            var campaignPriceStyle = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price")).GetCssValue("font-weight");

            duckInCampaign.Click();

            var titleofProduct = driver.FindElement(By.CssSelector("h1.title")).GetAttribute("textContent");
            var campaignPriceOnProdcuct = driver.FindElement(By.CssSelector("#box-product .campaign-price")).Text; ;
            var regularPriceOnProduct = driver.FindElement(By.CssSelector("#box-product .regular-price")).Text;
            var campaignPriceOnProdcuctColor = driver.FindElement(By.CssSelector("#box-product .campaign-price")).GetCssValue("color");
            var regularPriceOnProductColor = driver.FindElement(By.CssSelector("#box-product .regular-price")).GetCssValue("color");
            var regularPriceOnProductStyle = driver.FindElement(By.CssSelector("#box-product .regular-price")).GetCssValue("text-decoration");
            var campaignPriceOnProductStyle = driver.FindElement(By.CssSelector("#box-product .campaign-price")).GetCssValue("font-weight");


            Assert.AreEqual(nameOfTheDuck, titleofProduct, "Sth is wrong. Names are not the same.");
            Assert.AreEqual(campaignPrice, campaignPriceOnProdcuct, "Sth is wrong. Campaign prices are not the same.");
            Assert.AreEqual(regularPrice, regularPriceOnProduct, "Sth is wrong. Regular prices are not the same.");
            Assert.AreEqual(campaignPriceColor, campaignPriceOnProdcuctColor, "Campaign prices colors are not the same");
            Assert.AreEqual(regularPriceColor, regularPriceOnProductColor, "Regular prices colors are not the same");
            Assert.AreEqual(regularPriceStyle, regularPriceOnProductStyle, "Regular prices styles are not the same");
            Assert.AreEqual(campaignPriceStyle, campaignPriceOnProductStyle, "Campaign prices styles are not the same");

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
