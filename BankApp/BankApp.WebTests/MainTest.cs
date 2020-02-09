using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace WebTests
{
    public class MainTest : IDisposable
    {
        private readonly IWebDriver _driver;
        public MainTest()
        {
            _driver = new ChromeDriver();
        }

        [Fact]
        public void Page_Is_Loaded()
        {
            _driver.Navigate()
                .GoToUrl("https://webclient-test-wlba.azurewebsites.net/");
            Assert.Equal("React App", _driver.Title);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}
