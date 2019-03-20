using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.DataLayer
{
    /// <summary>
    /// static class to store the game data set
    /// </summary>
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Hitman",
                Age = 35,
                JobTitle = Player.JobTitleName.Explorer,
                Type = Character.RaceType.Human,
                Health = 150,
                Lives = 3,
                PerfamancePoints = 0,
                LocationId = 0
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "\tYou have been hired by the Space Mission Corporation to participate in its latest endeavor, the Space Mission Project. Your mission is to travel different location in Galaxy and report back to the Corporation.",
                "\tYou will begin by choosing a new location and using Space ship to travel to that point in the Galaxy."
            };
        }
    }
}
