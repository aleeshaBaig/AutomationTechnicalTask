using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;


public class CartPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public CartPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public bool IsProductInCart(string productName)
    {
        // Simplified example; you would check for the presence of the product and quantity here
        return driver.PageSource.Contains(productName);
    }

    // ... Other methods and properties ...

    public void AddItemToCart(string itemName)
    {

    }
}