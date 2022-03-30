namespace LetsGetTesting.Tests
{
    using System;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using WebDriverManager.DriverConfigs.Impl;

    public class LetsGetTestingSimple
    {
        public IWebDriver driver;

        [SetUp]
        public void SetupDriver()
        {
            // Setup Chrome driver and navigate to Google Maps page
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/maps";
        }

        [Test]
        public void SearchForDublinDirectionsAndValidateDestination_SingleFile()
        {
            // 1. Accept cookies
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
            // This will just work if browser opens in Portuguese, the locator is not the best...
            // Attempt to try a different approach by trying to add Google cookies into driver and access directly to Google Maps. But without success!
            By acceptButton = By.XPath("//span[@class='VfPpkd-vQzf8d'][text()='Aceito']");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(acceptButton));
            driver.FindElement(acceptButton).Click();

            // 2. Search for Dublin
            string destination = "Dublin";
            By searchBox = By.Id("searchboxinput");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(searchBox));
            
            driver.FindElement(searchBox).SendKeys(destination);
            driver.FindElement(searchBox).SendKeys(Keys.Enter);
            
            // 3. Verify left panel has "Dublin" as headline text
            By leftPanelHeader = By.XPath("//div[@id='pane']//h1/span");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(leftPanelHeader));
            Assert.IsTrue(driver.FindElement(leftPanelHeader).Displayed, "Left Panel is not displayed");

            string headlineText = driver.FindElement(leftPanelHeader).Text;
            Assert.AreEqual(headlineText, destination, "Dublin was not found in left panel");

            // 4. Click on Directions icon
            // directionsButton will work if browser opens in Portuguese
            By directionsButton = By.XPath("//div[@role='region']//button[contains(@data-value, 'Direções')]");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(directionsButton));
            driver.FindElement(directionsButton).Click();

            By travelModeOptions = By.XPath("//div[@role='radiogroup']");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(travelModeOptions));
            
            // 6. Verify destination field is "Dublin"
            By destinationBox = By.XPath("//div[@id='directions-searchbox-1']//input");

            Assert.IsTrue(driver.FindElement(destinationBox).Displayed, "Destination search box is not displayed");
            string currentDestinationName = driver.FindElement(destinationBox).GetAttribute("value");
            Assert.IsTrue(currentDestinationName.Contains(destination), "Destination Name does not match. Expected destination: " + destination + " Current destination: " + currentDestinationName);
        }
        
        // Close driver at the end of the test
        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}