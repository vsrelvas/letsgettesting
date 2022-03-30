namespace LetsGetTesting.Pages
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.PageObjects;
    using Utilities;
    using WebDriverManager;

    public class MapsPage
    {
        private IWebDriver driver;
        private UtilActions actions;
        
        public MapsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.actions = new UtilActions(driver);
        }
        
        private By searchBox = By.Id("searchboxinput");
        private By leftPanelHeader = By.XPath("//div[@id='pane']//h1/span");
        private By directionsButton = By.XPath("//div[@role='region']//button[contains(@data-value, 'Direções')]");
        private By travelModeOptions = By.XPath("//div[@role='radiogroup']");
        private By destinationBox = By.XPath("//div[@id='directions-searchbox-1']//input");

        public string HeadlineText()
        {
            return actions.WaitForElement(leftPanelHeader).Text;
        }
        
        public void SearchFor(string text)
        {
            actions.WaitForElement(searchBox).SendKeys(text);
            actions.WaitForElement(searchBox).SendKeys(Keys.Enter);
        }

        public void ClickOnDirections()
        {
            actions.WaitForElement(directionsButton).Click();
        }

        public string GetDestinationName()
        {
            return actions.WaitForElement(destinationBox).GetAttribute("value");
        }

        public bool WaitUntilSearchBoxIsDisplayed()
        {
            return actions.WaitForElement(searchBox).Displayed;
        }
        
        public bool WaitUntilHeaderIsDisplayed()
        {
            return actions.WaitForElement(leftPanelHeader).Displayed;
        }

        public bool WaitUntilDirectionsButtonIsDisplayed()
        {
            return actions.WaitForElement(directionsButton).Displayed;
        }

        public bool WaitUntilTravelOptionAreDisplayed()
        {
            return actions.WaitForElement(travelModeOptions).Displayed;
        }

        public bool WaitUntilDestinationBoxIsDisplayed()
        {
            return actions.WaitForElement(destinationBox).Displayed;
        }
    }
}