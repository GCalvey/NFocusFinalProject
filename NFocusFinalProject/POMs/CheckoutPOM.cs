using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusFinalProject.POMs
{
    //Enters all our details on the checkout page//
    public class CheckoutPOM
    {
        IWebDriver driver;

        public CheckoutPOM(IWebDriver driver)
        {
            this.driver = driver;
        }



        //Locates all the text boxes for the different fields on the page//
        public IWebElement firstName => driver.FindElement(By.Id("billing_first_name"));

        public IWebElement lastName => driver.FindElement(By.Id("billing_last_name"));

        public IWebElement EmailAddress => driver.FindElement(By.Id("billing_email"));

        public IWebElement Number => driver.FindElement(By.Id("billing_phone"));

        public IWebElement StreetAddress => driver.FindElement(By.Id("billing_address_1"));

        public IWebElement TownCity => driver.FindElement(By.Id("billing_city"));

        public IWebElement PostalCode => driver.FindElement(By.Id("billing_postcode"));

        public IWebElement CountrySelector => driver.FindElement(By.Id("select2-billing_country-container"));

        public IWebElement CountryChosen => driver.FindElement(By.CssSelector("input[role='combobox']"));





        // Submits the details for each field//
        public CheckoutPOM FirstNameCheckout(string First_name)
        {
            firstName.Clear();

            firstName.SendKeys(First_name);

            return this;

        }

        public CheckoutPOM LastNameDetails(string Last_name)
        {
            lastName.Clear();

            lastName.SendKeys(Last_name);

            return this;

        }

        public void  CountryCheckout()
        {
            CountrySelector.Click();

        }

        public CheckoutPOM CountryChosenCheckout(string Country)
        {
            CountryChosen.Clear();

            CountryChosen.SendKeys(Country);

            CountryChosen.SendKeys(Keys.Enter);

            return this;

        }

        public CheckoutPOM AddressCheckout(string Address)
        {
            StreetAddress.Clear();

            StreetAddress.SendKeys(Address);

            return this;

        }

        public CheckoutPOM CityCheckout(string City)
        {
            TownCity.Clear();

            TownCity.SendKeys(City);

            return this;

        }

        public CheckoutPOM PostcodeCheckout(string Postcode)
        {
            PostalCode.Clear();

            PostalCode.SendKeys(Postcode);

            return this;

        }

        public CheckoutPOM PhoneNumberCheckout(string Phone_Number)
        {
            Number.Clear();

            Number.SendKeys(Phone_Number);

            return this;

        }

        public CheckoutPOM EmailCheckout(string Email)
        {
            EmailAddress.Clear();

            EmailAddress.SendKeys(Email);

            return this;

        }



    }
}
