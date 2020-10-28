using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;
using System.IO;

namespace TrackerLibrary.DataAccess
{
    public class XmlConnector : IDataConnection
    {
        private const string PeopleFile = "PersonModels.xml";
        private const string PrizesFile = "PrizeModels.xml";
        private const string TeamFile = "TeamModels.xml";
        private const string TournamentFile = "TournamentModels.xml";

        public PersonModel CreatePerson(PersonModel model)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PersonModel>));
            List<PersonModel> people = new List<PersonModel>();

            if (File.Exists(PeopleFile.FullFilePath()))
            {
                using (XmlReader xmlReader = XmlReader.Create(PeopleFile.FullFilePath()))
                {
                    people = xmlSerializer.Deserialize(xmlReader) as List<PersonModel>;
                }
            }

            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            people.Add(model);

            using (XmlWriter xmlWriter = XmlWriter.Create(PeopleFile.FullFilePath()))
            {
                xmlSerializer.Serialize(xmlWriter, people);
            }

            return model;
        }

        public PrizeModel CreatePrize(PrizeModel model)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PrizeModel>));
            List<PrizeModel> prizes = new List<PrizeModel>();

            if (File.Exists(PrizesFile.FullFilePath()))
            {
                using (XmlReader xmlReader = XmlReader.Create(PrizesFile.FullFilePath()))
                {
                    prizes = xmlSerializer.Deserialize(xmlReader) as List<PrizeModel>;
                }
            }

            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            prizes.Add(model);

            using (XmlWriter xmlWriter = XmlWriter.Create(PrizesFile.FullFilePath()))
            {
                xmlSerializer.Serialize(xmlWriter, prizes);
            }

            return model;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<TeamModel>));
            List<TeamModel> teams = new List<TeamModel>();

            if (File.Exists(TeamFile.FullFilePath()))
            {
                using (XmlReader xmlReader = XmlReader.Create(TeamFile.FullFilePath()))
                {
                    teams = xmlSerializer.Deserialize(xmlReader) as List<TeamModel>;
                }
            }

            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            teams.Add(model);

            using (XmlWriter xmlWriter = XmlWriter.Create(TeamFile.FullFilePath()))
            {
                xmlSerializer.Serialize(xmlWriter, teams);
            }

            return model;
        }

        public void CreateTournament(TournamentModel model)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<TournamentModel>));
            List<TournamentModel> tournament = new List<TournamentModel>();

            if (File.Exists(TournamentFile.FullFilePath()))
            {
                using (XmlReader xmlReader = XmlReader.Create(TournamentFile.FullFilePath()))
                {
                    tournament = xmlSerializer.Deserialize(xmlReader) as List<TournamentModel>;
                }
            }

            int currentId = 1;

            if (tournament.Count > 0)
            {
                currentId = tournament.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            tournament.Add(model);

            using (XmlWriter xmlWriter = XmlWriter.Create(TournamentFile.FullFilePath()))
            {
                xmlSerializer.Serialize(xmlWriter, tournament);
            }
        }

        public List<PersonModel> GetPerson_All()
        {
            using (XmlReader xmlReader = XmlReader.Create(PeopleFile.FullFilePath()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PersonModel>));

                List<PersonModel> people = (List<PersonModel>)xmlSerializer.Deserialize(xmlReader);

                return people; 
            }
        }

        public List<TeamModel> GetTeam_All()
        {
            using (XmlReader xmlReader = XmlReader.Create(TeamFile.FullFilePath()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<TeamModel>));

                List<TeamModel> teams = (List<TeamModel>)xmlSerializer.Deserialize(xmlReader);

                return teams;
            }
        }

        public List<TournamentModel> GetTournament_All()
        {
            using (XmlReader xmlReader = XmlReader.Create(TournamentFile.FullFilePath()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<TournamentModel>));

                List<TournamentModel> tournament = (List<TournamentModel>)xmlSerializer.Deserialize(xmlReader);

                return tournament;
            }
        }
    }
}
