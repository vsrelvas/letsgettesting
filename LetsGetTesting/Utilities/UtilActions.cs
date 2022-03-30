namespace LetsGetTesting.Utilities
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.PageObjects;

    public class UtilActions
    {
        private IWebDriver driver;

        public UtilActions(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public IWebElement WaitForElement(By element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            try
            {
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            }
            catch (Exception e)
            {
                Console.WriteLine("Element is not displayed");
                throw;
            }
        }
    }
}