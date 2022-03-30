namespace LetsGetTesting.Pages
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;
    using Utilities;

    public class ConsentPage
    {
        private IWebDriver driver;
        private UtilActions actions;
        
        public ConsentPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.actions = new UtilActions(driver);
        }
        
        private By acceptButton = By.XPath("//span[@class='VfPpkd-vQzf8d'][text()='Aceito']");
        
        public bool WaitUntilAcceptButtonIsDisplayed()
        {
            return actions.WaitForElement(acceptButton).Displayed;
        }

        public void AcceptCookies()
        {
            actions.WaitForElement(acceptButton).Click();
        }
    }
}