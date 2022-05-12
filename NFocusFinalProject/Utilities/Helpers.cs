using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusFinalProject.Utilities
{
    public class Helpers
    {
        //This set waits for the automated test, this helps the test run//
        public static void WaitForElement(By locator, int TimeInSeconds, IWebDriver driver)
        {        
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeInSeconds));
            wait.Until(drv => drv.FindElement(locator).Displayed);
        }

        // Allows us to take a screenshot of the test in action//
        public static void CaptureScreenshot(ITakesScreenshot ssdriver, String ScreenshotName)
        {
            Screenshot screenshot = ssdriver.GetScreenshot();
            //Where the Screenshot will be saved//
            screenshot.SaveAsFile("C:\\Users\\GeorgeCalvey\\source\\repos\\NFocusFinalProject\\NFocusFinalProject\\Screenshots" + ScreenshotName + ".png", ScreenshotImageFormat.Png);
        }
    }
}
