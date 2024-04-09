using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

[Binding]
public class AddToCartSteps
{
    private IWebDriver driver;
    private HomePage homePage;
    private CartPage cartPage;
 
    [BeforeScenario]
    public void Setup()
    {
        driver = new ChromeDriver();
        homePage = new HomePage(driver);
        cartPage = new CartPage(driver);
    }

    [Given(@"I navigate to ""(.*)""")]
    public void GivenINavigateTo(string url)
    {
        homePage.NavigateTo(url);
        driver.Manage().Window.Maximize();
    }

    [When(@"I search for ""(.*)""")]
    public void WhenISearchFor(string itemName)
    {
        homePage.SearchForItem(itemName);
        // Implement navigation to the product and adding it to the cart here
     }
    [When(@"I add the item to the cart")]
    public void WhenIAddTheItemToTheCart()
    {
        // Implement the logic to add an item to the cart here.
        // The code below is just a placeholder and should be replaced with actual logic.
        var cartPage = new CartPage(driver); // Assuming you have a 'driver' and 'CartPage' defined appropriately.
        cartPage.AddItemToCart("AC1200 Gigabit WiFi Router (Archer A6) - Dual Band MU-MIMO Wireless Internet Router, 4 x Antennas, OneMesh and AP mode, Long Range Coverage");
    }

    [Then(@"The cart should contain ""(.*)"" AC1200 Gigabit WiFi Router with correct details")]
    public void ThenTheCartShouldContainWithCorrectDetails(int quantity)
    {
        Assert.IsTrue(cartPage.IsProductInCart("AC1200 Gigabit WiFi Router (Archer A6) - Dual Band MU-MIMO Wireless Internet Router, 4 x Antennas, OneMesh and AP mode, Long Range Coverage"));
        // Further checks for quantity and details can be added here
    }
    
    [AfterScenario]
    public void TearDown()
    {
        driver.Quit();
    }
}
