using Core.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

public static class Wait
{
    public static IWebElement WaitUtil(this IWebDriver driver, By elementLocator, WaitType waitType = WaitType.WaitUtilVisible, int timeout = Constant.TimeOut)
    {
        switch (waitType)
        {
            case WaitType.WaitUtilVisible:
                return driver.WaitUntilElementVisible(elementLocator, timeout);
            case WaitType.WaitUtilExist:
                return driver.WaitUntilElementExist(elementLocator, timeout);
            case WaitType.WaitUtilClickable:
                return driver.WaitUntilElementClickable(elementLocator, timeout);
            default:
                throw new Exception("Invalid web type!");
        }
    }

    private static IWebElement WaitUntilElementVisible(this IWebDriver driver, By elementLocator, int timeout = Constant.TimeOut)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
        }
        catch (Exception)
        {
            throw new Exception("Element with locator: '" + elementLocator + "' was not visible.");
        }
    }

    private static IWebElement WaitUntilElementExist(this IWebDriver driver, By elementLocator, int timeout = Constant.TimeOut)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
        }
        catch (Exception)
        {
            throw new Exception("Element with locator: '" + elementLocator + "' was not exist.");
        }
    }


    private static IWebElement WaitUntilElementClickable(this IWebDriver driver, By elementLocator, int timeout = Constant.TimeOut)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
        }
        catch (Exception)
        {
            throw new Exception("Element with locator: '" + elementLocator + "' was not clickable.");
        }
    }

    public static IWebDriver Sleep(this IWebDriver driver, int millisecondsTimeout)
    {
        Thread.Sleep(millisecondsTimeout);
        return driver;
    }

    public static IAlert WaitForAlert(this IWebDriver driver, int timeOutSeconds = Constant.TimeOut)
    {
        var timeOut = TimeSpan.FromSeconds(timeOutSeconds);
        var wait = new WebDriverWait(driver, timeOut);
        wait.Until(driver => driver.IsAlertShown());
        var result = driver.SwitchTo().Alert();

        return result;
    }

    public static void WaitForPageLoad(this IWebDriver driver)
    {
        var wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
        try
        {
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState == 'complete' && jQuery.active == 0").Equals(true));
        }
        catch
        {
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState == 'complete'").Equals(true));
        }
    }

    private static bool IsAlertShown(this IWebDriver driver)
    {
        try
        {
            driver.SwitchTo().Alert();
        }
        catch
        {
            return false;
        }
        return true;
    }

}
