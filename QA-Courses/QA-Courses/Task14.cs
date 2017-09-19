using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Courses
{
    [TestFixture]
    public class Task14
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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [Test]
        public void TestFromTaskFourteen()
        {
            driver.Url = "http://localhost/litecard/public_html/admin/login.php?redirect_url=%2Flitecard%2Fpublic_html%2Fadmin%2F";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            driver.FindElement(By.XPath("//span[contains(text(),'Countries')]")).Click();

            driver.FindElement(By.CssSelector("#content > div > a")).Click();

            IList<IWebElement> listOfExternalLinks = driver.FindElements(By.ClassName("fa-external-link"));
            
            foreach (IWebElement link in listOfExternalLinks)
            {
                string mainWindow = driver.CurrentWindowHandle;
                IList<string> oldWindows = driver.WindowHandles;
                link.Click();
                
                string newWindow = wait.Until(example =>
                {
                    IList<string> newWindows = driver.WindowHandles;
                    IList<string> outstandingWindows = newWindows.Except(oldWindows).ToList();

                    if (outstandingWindows.Count > 0)
                    {
                        return outstandingWindows.FirstOrDefault();
                    }
                    else
                    {
                        return null;
                    }
                });

                driver.SwitchTo().Window(newWindow);
                driver.Close();
                driver.SwitchTo().Window(mainWindow);
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
