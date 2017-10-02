using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Courses.Task19.Driver;

namespace QA_Courses.Task19.Test
{
    public class TestBase
    {

        [SetUp]
        public void start()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            DriverContext.Driver = new ChromeDriver(options);
        }
        /*
        [TearDown]
        public void stop()
        {
            DriverContext.Driver.Quit();
        }
        */
    }
}
