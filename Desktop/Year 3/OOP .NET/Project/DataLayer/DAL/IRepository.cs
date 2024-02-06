using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public interface IRepository
    {
        public enum Gender { Men, Women}

        Task<List<Team>> GetTeams(Gender gender);
        Task<Team> GetTeam(int id, Gender gender);

        Task<List<Match>> GetMatches(Gender gender);
        Task<Match> GetMatch(int id, Gender gender);
        Task<List<Match>> GetMatchesByFifaCode(string fifaCode, Gender gender);

        Task<List<Player>> GetPlayers(string fifaCode,Gender gender);
        Task<Player> GetPlayer(int id,string fifaCode, Gender gender);
        Task<List<Player>> GetStartingPlayers(string fifaCode, Gender gender);


    }
}
