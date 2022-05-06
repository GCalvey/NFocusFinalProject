using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusFinalProject.POMs
{
    //Enters all our details on the checkout page//
    public class DetailsForCheckoutPOM
    {
        IWebDriver driver;

        public DetailsForCheckoutPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Locates all the text boxes for the different fields on the page//
        public IWebElement first_Name => driver.FindElement(By.Id("billing_first_name"));

        public IWebElement last_Name => driver.FindElement(By.Id("billing_last_name"));

        public IWebElement Email_address => driver.FindElement(By.Id("billing_email"));

        public IWebElement Number => driver.FindElement(By.Id("billing_phone"));

        public IWebElement Street_address => driver.FindElement(By.Id("billing_address_1"));

        public IWebElement Town_city => driver.FindElement(By.Id("billing_city"));

        public IWebElement Postal_code => driver.FindElement(By.Id("billing_postcode"));

        public IWebElement Country_selector => driver.FindElement(By.Id("select2-billing_country-container"));

        public IWebElement Country_chosen => driver.FindElement(By.CssSelector("input[role='combobox']"));

        // Submits the details for each field//
        public DetailsForCheckoutPOM FirstName_Checkout(string First_name)
        {
            first_Name.Clear();

            first_Name.Click();

            first_Name.SendKeys(First_name);

            return this;

        }

        public DetailsForCheckoutPOM LastName_Details(string Last_name)
        {
            last_Name.Clear();

            last_Name.Click();

            last_Name.SendKeys(Last_name);

            return this;

        }

        public void  Country_Checkout()
        {
            Country_selector.Click();

        }

        public DetailsForCheckoutPOM CountryChosen_Checkout()
        {
            Country_chosen.Clear();

            Country_chosen.SendKeys("United Kingdom");

            Country_chosen.SendKeys(Keys.Enter);

            return this;

        }

        public DetailsForCheckoutPOM Address_Checkout(string Address)
        {
            Street_address.Clear();

            Street_address.Click();

            Street_address.SendKeys(Address);

            return this;

        }

        public DetailsForCheckoutPOM City_Checkout(string City)
        {
            Town_city.Clear();

            Town_city.Click();

            Town_city.SendKeys(City);

            return this;

        }

        public DetailsForCheckoutPOM Postcode_Checkout(string Postcode)
        {
            Postal_code.Clear();

            Postal_code.Click();

            Postal_code.SendKeys(Postcode);

            return this;

        }

        public DetailsForCheckoutPOM PhoneNumber_Checkout(string Phone_Number)
        {
            Number.Clear();

            Number.Click();

            Number.SendKeys(Phone_Number);

            return this;

        }

        public DetailsForCheckoutPOM Email_Checkout(string Email)
        {
            Email_address.Clear();

            Email_address.Click();

            Email_address.SendKeys(Email);

            return this;

        }



    }
}
