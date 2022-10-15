using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace ITWorx.Utlities
{
    public class DriverOperations
    {
        private IWebDriver _driver;

        public DriverOperations(IWebDriver driver)
        {
            _driver = driver;
        }

        public void CloseBrowser()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }

        public void SortDescending(IWebElement element)
        {
            Actions action = new Actions(_driver);
            action.DragAndDropToOffset(element, 30, 0).Build().Perform();
            action.DoubleClick(element).Build().Perform();
        }

        public void SortAscending(IWebElement element)
        {
            element.Click();
        }

        public void WaitForElementToBeVisible(IWebElement element, int time)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(time));
            wait.Until(d => element.Displayed);
        }
    }
}
