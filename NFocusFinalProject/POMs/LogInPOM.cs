using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace NFocusFinalProject.POMs
{
    //Logging in as a registered user on the website//
    public class LogInPOM
    {
        IWebDriver driver;

        public LogInPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Closes down a cookie banner that appears when opening the page//
        public IWebElement BannerDismiss => driver.FindElement(By.ClassName("woocommerce-store-notice__dismiss-link"));

        //Finds the text boxes for the User and Password//
        public IWebElement Username => driver.FindElement(By.Id("username"));

        public IWebElement Password => driver.FindElement(By.Id("password"));

        //Locates the login button//
        public IWebElement Login => driver.FindElement(By.Id("login"));

        //Clicks the Banner off//
        public void dismiss()
        {
            BannerDismiss.Click();
        }

        //Submits the Username and Password//
        public LogInPOM LoginUser (string username)
        {
            Username.SendKeys(username);

            return this;
        }
        
        public LogInPOM LoginPassword(string password)
        {
            Password.SendKeys(password);
            
            return this;
        }
    }
}
