using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.UnitTest.Test.Actions.UI.BrowserFactoryTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class BrowserTests
    {

        IWebDriver driver;


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void GetBrowser_GetChromeBrowser_Successfully()
        {

            driver = Browser.Init().GetBrowser("Chrome");
            Assert.IsNotNull(driver);
        }


        [Test]
        public void GetBrowser_GetChromeBrowserHeadless_Successfully()
        {

            driver = Browser.Init().GetBrowser("Chrome", true);
            Assert.IsNotNull(driver);
        }
    }
}
