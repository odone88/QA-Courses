using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace QA_Courses
{
    [TestFixture]
    public class Task13
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
        public void TestFromTaskThirteen()
        {
            driver.Url = "http://localhost/litecard/public_html/en/";




            var linkToSomeProduct = driver.FindElement(By.CssSelector("#box-most-popular > div > ul > li:nth-child(4) > a.link > div.name"));
            
            linkToSomeProduct.Click();

            if (driver.FindElement(By.CssSelector("#box-product > div:nth-child(1) > h1")).Text == "Yellow Duck")
            {
                new SelectElement(driver.FindElement(By.Name("options[Size]"))).SelectByText("Small");
            }


            var addToCartBtn = driver.FindElement(By.Name("add_cart_product"));
            addToCartBtn.Click();
            var numberOfProducts = driver.FindElement(By.ClassName("quantity"));
            wait.Until(ExpectedConditions.TextToBePresentInElement(numberOfProducts, "1"));

            var logoBtn = driver.FindElement(By.Id("logotype-wrapper"));
            logoBtn.Click();

            wait.Until(ExpectedConditions.StalenessOf(addToCartBtn));
            var linkToSomeProduct2 = driver.FindElement(By.CssSelector("#box-most-popular div.image-wrapper > img"));
            linkToSomeProduct2.Click();

            if (driver.FindElement(By.CssSelector("#box-product > div:nth-child(1) > h1")).Text == "Yellow Duck")
            {
                new SelectElement(driver.FindElement(By.Name("options[Size]"))).SelectByText("Small");
            }


            var addToCartBtn2 = driver.FindElement(By.Name("add_cart_product"));
            addToCartBtn2.Click();
            var numberOfProducts2 = driver.FindElement(By.ClassName("quantity"));
            wait.Until(ExpectedConditions.TextToBePresentInElement(numberOfProducts2, "2"));

            var logoBtn2 = driver.FindElement(By.Id("logotype-wrapper"));
            logoBtn2.Click();
            wait.Until(ExpectedConditions.StalenessOf(addToCartBtn2));

            var linkToSomeProduct3 = driver.FindElement(By.CssSelector("#box-most-popular div.image-wrapper > img"));
            linkToSomeProduct3.Click();
            if (driver.FindElement(By.CssSelector("#box-product > div:nth-child(1) > h1")).Text == "Yellow Duck")
            {
                new SelectElement(driver.FindElement(By.Name("options[Size]"))).SelectByText("Small");
            }


            var addToCartBtn3 = driver.FindElement(By.Name("add_cart_product"));
            addToCartBtn3.Click();
            var numberOfProducts3 = driver.FindElement(By.ClassName("quantity"));
            wait.Until(ExpectedConditions.TextToBePresentInElement(numberOfProducts3, "3"));

            driver.FindElement(By.CssSelector("#cart > a.link")).Click();

            IList<IWebElement> shortcuts = driver.FindElements(By.ClassName("shortcut"));
            if (shortcuts.Count == 2)
            {
                wait.Until(ExpectedConditions.StalenessOf(addToCartBtn3));
                var product3alt = driver.FindElement(By.CssSelector("#order_confirmation-wrapper tr:nth-child(3) > td.item"));
                driver.FindElement(By.Name("remove_cart_item")).Click();


                wait.Until(ExpectedConditions.StalenessOf(product3alt));
                var product2alt = driver.FindElement(By.CssSelector("#order_confirmation-wrapper tr:nth-child(2) > td.item"));
                driver.FindElement(By.Name("remove_cart_item")).Click();


                wait.Until(ExpectedConditions.StalenessOf(product2alt));


            }
            else
            {


                wait.Until(ExpectedConditions.StalenessOf(addToCartBtn3));
                var product3 = driver.FindElement(By.CssSelector("#order_confirmation-wrapper tr:nth-child(4) > td.item"));
                driver.FindElement(By.Name("remove_cart_item")).Click();


                wait.Until(ExpectedConditions.StalenessOf(product3));
                var product2 = driver.FindElement(By.CssSelector("#order_confirmation-wrapper tr:nth-child(3) > td.item"));
                driver.FindElement(By.Name("remove_cart_item")).Click();


                wait.Until(ExpectedConditions.StalenessOf(product2));
                var product1 = driver.FindElement(By.CssSelector("#order_confirmation-wrapper tr:nth-child(2) > td.item"));
                driver.FindElement(By.Name("remove_cart_item")).Click();


                wait.Until(ExpectedConditions.StalenessOf(product1));
            }



        }
        
                [TearDown]
                public void stop()
                {
                    driver.Quit();
                    driver = null;
                }
                
    }
}
