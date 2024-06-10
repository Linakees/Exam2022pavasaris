using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WindowsForms.Tests.Tests
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ebay.com");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        [Test]
        public void Test1_field()
        {
            IWebElement searchInput = driver.FindElement(By.Id("gh-ac"));
            Assert.IsNotNull(searchInput, "Search input element not found");
        }

        [Test]
        public void Test2_search()
        {
            IWebElement searchButton = driver.FindElement(By.Id("gh-btn"));
            Assert.IsNotNull(searchButton, "Search button element not found");
        }
    }
}
