using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class HomePage
{
    private IWebDriver driver;
    private string cookiesFilePath = "cookies.json";

    public HomePage(IWebDriver existingDriver)
    {
        this.driver = existingDriver;
        this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    public static IWebDriver InitializeDriver()
    {
        ChromeOptions options = new ChromeOptions();

        // Set a custom user-agent to mimic a regular browser session
        options.AddArgument("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36" +
            "");

        // You can add other ChromeOptions here if needed
        // ...
        options.AddArgument(@"/Users/macbook/Library/Application Support/Google/Chrome/Profile 1");


        IWebDriver driver = new ChromeDriver(options);
        driver.Manage().Window.Size = new System.Drawing.Size(1366, 768); // Optional: Set a common window size
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(400);
        return driver;
    }

    public void NavigateTo(string url)
    {
        driver.Navigate().GoToUrl(url);
        LoadCookies(); // Load the cookies after navigating to the desired URL

        // Navigate to the URL again to ensure cookies are recognized by the site
        driver.Navigate().GoToUrl(url);
        driver.Manage().Window.Maximize();
    }

    public void SearchForItem(string itemName)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(400);
        var searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(400);
        searchBox.SendKeys(itemName + Keys.Enter);
        var item = driver.FindElement(By.PartialLinkText("TP-Link AC1200"));
        item.Click();


        // Click on the "Add to Cart" button
        var addToCartButton = driver.FindElement(By.Id("add-to-cart-button"));
        addToCartButton.Click();
        driver.Quit();
    }
    
  
    public void LoadCookies()
    {
        if (File.Exists(cookiesFilePath))
        {
            driver.Navigate().GoToUrl("https://www.amazon.com/"); // Navigate to the domain first to set the domain cookies
            var cookies = JsonConvert.DeserializeObject<List<Cookie>>(File.ReadAllText(cookiesFilePath));
            foreach (var cookie in cookies)
            {
                driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, cookie.Expiry));
            }
            driver.Navigate().Refresh(); // Refresh the page to apply the cookies
        }
    }

    public void SaveCookies()
    {
        var cookies = driver.Manage().Cookies.AllCookies;
        File.WriteAllText(cookiesFilePath, JsonConvert.SerializeObject(cookies));
    }

    public void WaitForPageToLoad()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
        wait.Until(wd => ((IJavaScriptExecutor)wd).ExecuteScript("return document.readyState").ToString().Equals("complete"));
    }
}
