using ITWorx.Utlities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace ITWorx.Pages
{
    public class HomePage
    {
        private IWebDriver _driver;
        DriverOperations dop;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            dop = new DriverOperations(_driver);
        }

        #region objects
        private IWebElement _teamInFirstRow => _driver.FindElement(By.CssSelector("div[row-index='0'] div[col-id='team'] span"));
        private IWebElement _columnHeader(string element) => _driver.FindElement(By.XPath($"//span[text()='{element}']/ancestor::div[@ref='eLabel']"));
        private IWebElement _topFilter(string name) => _driver.FindElement(By.XPath($"//span[text()='{name}']/ancestor::button"));
        private IWebElement _columnFilterIcon(string columnName) => _driver.FindElement(By.XPath($"//span[text()='{columnName}']/../preceding-sibling::span"));
        private IWebElement _textFilterIcon => _driver.FindElement(By.XPath("//div[@ref='eHeader']/span[2]"));
        private IWebElement _searchField => _driver.FindElement(By.XPath("(//input[@ref='eInput'][@aria-label='Filter Value'])[1]"));
        private IList<IWebElement> _playersName => _driver.FindElements(By.CssSelector("div[col-id='player'][role='gridcell'] span"));
        private IWebElement _desiredTeam(string team) => _driver.FindElement(By.XPath($"//div[@row-index = '0']//img[@alt='{team}']"));
        private IWebElement selectedLeague(string leagueName) => _driver.FindElement(By.XPath($"//span[text()='{leagueName}']/ancestor::button[contains(@class,'button-selected')]"));

        #endregion objects

        public bool IsTheLeagueSelected(string leagueName)
        {
            try
            {
                return selectedLeague(leagueName).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetTeamWithHighestValue(string columnName, bool IsAscendaing = true)
        {
            if (IsAscendaing)
            {
                dop.SortAscending(_columnHeader(columnName));
            }
            else
            {
                dop.SortDescending(_columnHeader(columnName));
            }
            return _teamInFirstRow.Text;
        }

        public void SelectQuickFilter(string filterName)
        {
            _topFilter(filterName).Click();
        }

        public void FilterFromGridByText(string columnName, string clubName)
        {
            _columnFilterIcon(columnName).Click();
            _textFilterIcon.Click();
            _searchField.SendKeys(clubName);
            _searchField.SendKeys(Keys.Enter);
            dop.WaitForElementToBeVisible(_desiredTeam(clubName), 10);
            _desiredTeam(clubName).Click();

        }

        public List<string> GetPlayersName()
        {
            List<string> players = new List<string>();
            foreach (var player in _playersName)
            {
                players.Add(player.Text);
            }
            return players;
        }
    }
}
