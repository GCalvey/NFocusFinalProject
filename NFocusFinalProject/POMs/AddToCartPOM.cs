using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusFinalProject.POMs
{
    //This POM adds a specific item to the cart//
    public class AddToCartPOM
    {
        IWebDriver driver;

        public AddToCartPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Finds the link to the shop page//
        public IWebElement ShopLink => driver.FindElement(By.Id("menu-item-43"));
        
        //Finds the button for the item we want to add to our basket//
        public IWebElement Add_HoodieWithLogo => driver.FindElement(By.CssSelector(".has-post-thumbnail.instock.post-31.product.product-type-simple.product_cat-hoodies.purchasable.shipping-taxable.status-publish.type-product > .add_to_cart_button.ajax_add_to_cart.button.product_type_simple"));

        //Finds the button to view our cart//
        public IWebElement View_Cart => driver.FindElement(By.ClassName("cart-contents"));

        public void AddHoodieWithLogo()
        {
            //Clicks the shop link//
            ShopLink.Click();

            //Adds the item to our basket//
            Add_HoodieWithLogo.Click();

            //Takes us to view out basket//
            View_Cart.Click();
        }



    }
}
