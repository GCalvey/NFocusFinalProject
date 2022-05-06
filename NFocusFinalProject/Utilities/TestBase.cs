using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusFinalProject.TestBase
{
    [Binding]
    
    public class TestBase
    {
        public static IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public TestBase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        //Opens the browser, sets the size and the page we want to go to//
        [BeforeScenario]
        public void Setup()
        {

            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            _scenarioContext["webdriver"] = driver;

            string BaseUrl = Environment.GetEnvironmentVariable("BaseUrl");

            driver.Url = BaseUrl;
            
        }

        //Clears the basket after our first test//
        [AfterScenario ("Coupon")]

        public static void ClearBasket()
        {
            driver.FindElement(By.Id("menu-item-44")).Click();
            driver.FindElement(By.CssSelector(".remove")).Click();
        }

        //Closes the browser once the tests have finished//
        [AfterScenario]

        public void TearDown()
        {
            
            driver.FindElement(By.Id("menu-item-46")).Click();
            driver.FindElement(By.PartialLinkText("Log out")).Click();

            driver.Quit();
        }
    }
}
