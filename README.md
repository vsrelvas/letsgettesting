# LetsGetTesting
Automation framework including one test to search for a city in Google Maps using Selenium.

# Getting Started 
1. Clone the project: `git@github.com:vsrelvas/letsgettesting.git`
2. Open the project in your IDE (Visual Studio or Rider, for example)
3. Compile de code
4. Run test

# Tests
1. Inside /Tests folder:
* LetsGetTestingSimple.cs include the SearchForDublinDirectionsAndValidateDestination_SingleFile test. This class can be run itself without need the rest of framework classes.
* LetsGetTesting.cs include the SearchForDublinDirectionsAndValidateDestination test. This class depends on the framework structure inheriting the methods inside BaseTest  

# Framework Structure
* Tests: scenario under validation
* Pages: define locators and methods for Consent page and Maps page
* Utilities: methods used acrossed framework in order to open/close browser and generic method to wait for element be visible.
