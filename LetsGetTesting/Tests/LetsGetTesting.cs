namespace LetsGetTesting.Tests
{
    using NUnit.Framework;
    using Pages;
    using Utilities;

    public class LetsGetTesting : BaseTest
    {
        [Test]
        public void SearchForDublinDirectionsAndValidateDestination()
        {
            // 1. Navigate to maps page and accept cookies
            ConsentPage consentPage = new ConsentPage(driver);
            Assert.IsTrue(consentPage.WaitUntilAcceptButtonIsDisplayed(), "Button to Accept cookies is not displayed");
            consentPage.AcceptCookies();

            // 2. Search for Dublin
            string destination = "Dablin";
            MapsPage mapsPage = new MapsPage(driver);
            Assert.IsTrue(mapsPage.WaitUntilSearchBoxIsDisplayed(), "Search element is not displayed.");
            mapsPage.SearchFor(destination);
            
            // 3. Verify left panel has "Dublin" as headline text
            Assert.IsTrue(mapsPage.WaitUntilHeaderIsDisplayed(), "Left Panel is not displayed");
            string headlineText = mapsPage.HeadlineText();
            Assert.AreEqual(headlineText, destination, "Dublin was not found in left panel");
            
            // 4. Click on Directions icon
            Assert.IsTrue(mapsPage.WaitUntilDirectionsButtonIsDisplayed(), "Directions button is not displayed");
            mapsPage.ClickOnDirections();
            Assert.IsTrue(mapsPage.WaitUntilTravelOptionAreDisplayed(), "Travel mode options are displayed.");
            
            // 5. Verify destination field is "Dublin"
            Assert.IsTrue(mapsPage.WaitUntilDestinationBoxIsDisplayed(), "Destination search box is not displayed");
            string currentDestinationName = mapsPage.GetDestinationName();
            Assert.IsTrue(currentDestinationName.Contains(destination), "Destination Name does not match. Expected destination: " + destination + " Current destination: " + currentDestinationName);
        }
    }
}