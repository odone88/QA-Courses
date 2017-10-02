using NUnit.Framework;
using QA_Courses.Task19.Driver;
using QA_Courses.Task19.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Courses.Task19.Test
{
    [TestFixture]
    public class CustomerRegistrationTests : TestBase
    {
        [TestCase]
        public void CanUserAddProductsToCartAndDeleteThemTest()
        {
            MainPage mainPage = new MainPage(DriverContext.Driver);
            mainPage.Open();
            ProductPage productPage = mainPage.ClickOnProduct();
            productPage.AddProductToCart("1");
            productPage.GoToMainPage();
            mainPage.ClickOnProduct();
            productPage.AddProductToCart("2");
            productPage.GoToMainPage();
            mainPage.ClickOnProduct();
            productPage.AddProductToCart("3");
            CartPage cartPage = new CartPage(DriverContext.Driver);
            cartPage.GoToCartPage();
            Assert.IsTrue(cartPage.DeleteProductsAndCheckIfTheyStillExists(), "Not all products were deleted. Please investigate.");
        }
    }
}
