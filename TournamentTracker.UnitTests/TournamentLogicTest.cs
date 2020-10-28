using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackerLibrary.Models;
using TrackerLibrary;
using System.Collections.Generic;

namespace TournamentTracker.UnitTests
{
    [TestClass]
    public class TournamentLogicTest
    {
        [TestMethod]
        public void CreateRounds_CreatedTreeRounds_ReturnsTrue()
        {
            TournamentModel model = new TournamentModel();
            List<TeamModel> teams = new List<TeamModel> { new TeamModel(),
                new TeamModel(),
                new TeamModel(),
                new TeamModel(),
                new TeamModel(),
                new TeamModel(),
                new TeamModel(),
                new TeamModel()
            };

            model.EnteredTeams = teams;

            TournamentLogic.CreateRounds(model);

            Assert.AreEqual(3, model.Rounds.Count);
        }
    }
}
