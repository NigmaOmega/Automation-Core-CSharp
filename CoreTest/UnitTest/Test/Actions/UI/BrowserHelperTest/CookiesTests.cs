using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Core.UnitTest.Test.Actions.UI.BrowserHelperTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class CookiesTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = Browser.Init().GetBrowser("Chrome", true);
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void AddCookie_WithValidCookieKeyValue_Successfully()
        {

            driver.Navigate().GoToUrl("https://www.google.com/");
            var cookiesBefore = driver.GetAllCookies();
            driver.AddCookie("test", "test");
            var cookiesAfter = driver.GetAllCookies();

            Assert.Less(cookiesBefore.Count, cookiesAfter.Count);
        }

        [Test]
        public void AddCookie_WithValidCookie_Successfully()
        {

            driver.Navigate().GoToUrl("https://www.google.com/");
            var cookiesBefore = driver.GetAllCookies();
            Cookie cookie = new Cookie("test", "test");
            driver.AddCookie(cookie);
            var cookiesAfter = driver.GetAllCookies();

            Assert.Less(cookiesBefore.Count, cookiesAfter.Count);
        }

        [Test]
        public void AddCookies_WithValidCookies_Successfully()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            var cookiesBefore = driver.GetAllCookies();
            Cookie cookie = new Cookie("test", "test");
            List<Cookie> cookies = new List<Cookie>();
            cookies.Add(cookie);
            driver.AddCookies(cookies);
            var cookiesAfter = driver.GetAllCookies();

            Assert.Less(cookiesBefore.Count, cookiesAfter.Count);
        }

        [Test]
        public void GetAllCookies_WithValidUrl_Successfully()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            var cookies = driver.GetAllCookies();

            Assert.Greater(cookies.Count, 1);
        }

        [Test]
        public void DeleteAllCookies_WithValidUrl_Successfully()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/");
            driver.DeleteAllCookies();
            var cookies = driver.GetAllCookies();

            Assert.AreEqual(0, cookies.Count);
        }
    }
}
