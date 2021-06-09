using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.UnitTest.Test.Actions.UI
{
    [TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)]
    class ElementActionsTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = Browser.Init().GetBrowser("Chrome", true);
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void ClickAndHold_OnValidElement_NoEception()
        {
            By firstName = By.Id("firstName");
            driver.ClickAndHold(firstName);
        }

        [Test]
        public void RightClick_OnValidElement_NoEception()
        {
            By firstName = By.Id("firstName");
            driver.RightClick(firstName);
        }

        [Test]
        public void DoubleClick_OnValidElement_NoEception()
        {
            By firstName = By.Id("firstName");
            driver.DoubleClick(firstName);
        }

        [Test]
        public void Hover_OnValidElement_NoEception()
        {
            By firstName = By.Id("firstName");
            driver.Hover(firstName);
        }

        [Test]
        public void MoveByOffset_OnValidElement_NoEception()
        {
            driver.MoveByOffset(100, 100);
        }

        [Test]
        public void DragAndDrop_OnValidElement_NoEception()
        {
            driver.Navigate().GoToUrl("https://crossbrowsertesting.github.io/drag-and-drop");
            var source = By.Id("draggable");
            var target = By.Id("droppable");
            driver.DragAndDrop(source, target);
        }

        [Test]
        public void DragAndDropBy_OnValidElement_NoEception()
        {
            driver.Navigate().GoToUrl("https://crossbrowsertesting.github.io/drag-and-drop");
            var source = By.Id("draggable");
            var targetEle = driver.WaitUtil(By.Id("droppable"));

            int targetEleXOffset = targetEle.Location.X;
            int targetEleYOffset = targetEle.Location.Y;
            driver.DragAndDropBy(source, targetEleXOffset, targetEleYOffset);
        }

        [Test]
        public void ClickHoldAndRelease_OnValidElement_NoEception()
        {
            driver.Navigate().GoToUrl("https://crossbrowsertesting.github.io/drag-and-drop");
            var sourceEle = By.Id("draggable");
            var targetEle = By.Id("droppable");
            driver.ClickHoldAndRelease(sourceEle, targetEle);
        }
    }
}
