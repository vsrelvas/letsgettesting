namespace LetsGetTesting.Utilities
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using WebDriverManager.DriverConfigs.Impl;

    public class BaseTest
    {
        protected IWebDriver driver;
        
        [SetUp]
        public void SetupDriver()
        {
            // TO DO: set a "Browser" variable in a config file and get value to use it in SetBrowser() method
            SetBrowser("Chrome");
            driver.Url = "https://www.google.com/maps";
            
            // TO DO:
            // Instead to click on "Aceito" cookies button, try to add Google cookies in driver and access directly to Google Maps:
            /*
            var cookiesList = driver.Manage().Cookies.AllCookies;
            foreach (var cookie in cookiesList)
            {
                driver.Manage().Cookies.AddCookie(new Cookie(cookie.Name, cookie.Value));
            } */
            
            // Or access to this Url
            // driver.Url = "https://consent.google.com/ml?continue=https://www.google.com/maps/&gl=GB&m=0&pc=m&hl=en&src=1";
        }

        public void SetBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
            }
        }
        
        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}