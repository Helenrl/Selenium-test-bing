using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SeleniumBingTests
{
   
    [TestClass]
    public class MySeleniumTests
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string bingURL;

        public MySeleniumTests()
        {
        }

        [TestMethod]
        [TestCategory("Firefox")]
        public void TheBingSearchTest1WithSelenium()
        {
            driver.Navigate().GoToUrl(bingURL + "/");
            driver.FindElement(By.Id("sb_form_q")).SendKeys("Selenium");
            driver.FindElement(By.Id("sb_form_go")).Click();
            Assert.IsTrue(driver.Title.Contains("Selenium"), "Verified title of the page");
        }

        [TestMethod]
        [TestCategory("Firefox")]
        public void TheBingSearchTest2WithNothing()
        {
            driver.Navigate().GoToUrl(bingURL + "/");
            driver.FindElement(By.Id("sb_form_q")).SendKeys("");
            driver.FindElement(By.Id("sb_form_go")).Click();
            Assert.IsTrue(driver.Title.Contains(""), "Verified title of the page");
        }

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            bingURL = "http://www.bing.com/";

            string browser = "Firefox";
                   
            switch (browser)
            {
               
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new InternetExplorerDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}