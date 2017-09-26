using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Courses
{
    [TestFixture]
    public class RemoteTricks
    {

        private IWebDriver driver1;
        private WebDriverWait wait;



        [SetUp]
        public void start()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--start-maximized");
            //options.ToCapabilities();

            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--start-maximized");
            options.ToCapabilities();
            DesiredCapabilities capability = DesiredCapabilities.Chrome();
            capability.SetCapability("browserstack.user", "mateuszrutkowski1");
            capability.SetCapability("browserstack.key", "mCGpmwgUs8zmmJvCpaLf");
            capability.SetCapability("build", "First build");
            capability.SetCapability("browserstack.debug", "true");


            driver1 = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability);
            driver1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver1, TimeSpan.FromSeconds(20));
        }

        [Test]
        public void RemoteTricksTest()
        {
            driver1.Url = "http://www.fcbarca.com/";

        }

        [TearDown]
        public void stop()
        {
            driver1.Quit();
            driver1 = null;
        }

    }
}
