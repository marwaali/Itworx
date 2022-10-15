using ITWorx.Pages;
using ITWorx.Utlities;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace ITWorx.TestCases
{
    public class Tests:BaseTest
    {
        
        [Test]
        public void TestCase()
        {
            HomePage home = new HomePage(driver);
            Assert.IsTrue(home.IsTheLeagueSelected("English Premier League"), "The desired league isn't selected");
            Assert.AreEqual("Arsenal", home.GetTeamWithHighestValue("League Position"), "The highest point team isn't matched");
            Assert.AreEqual("Manchester City", home.GetTeamWithHighestValue("Goals For", false), "The highest goal for team isn't matched");
            home.SelectQuickFilter("Top 20 Scorers");
            home.FilterFromGridByText("Club", "Liverpool");
            List<string> players = home.GetPlayersName();
            DirectoryInfo directory = Directory.CreateDirectory(projDir + @"\ITWorx\players");
            FileHandler.WriteDataToNotePade(directory.FullName, players);
        }
    }
}