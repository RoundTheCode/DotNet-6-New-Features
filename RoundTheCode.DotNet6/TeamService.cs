using System.Collections.Generic;

namespace RoundTheCode.DotNet6
{
    public class TeamService : ITeamService
    {
        public TeamService()
        {
            TeamListing = new Dictionary<int, Team>();
            NextId = 0;
        }

        public Dictionary<int, Team> TeamListing { get; set; }

        public int NextId { get; set; }

        public Team Create(Team team)
        {
            team.Id = NextId + 1;
            NextId++;

            TeamListing.Add(team.Id, team);

            return team;
        }

        public void Delete(int id)
        {
            if (TeamListing.ContainsKey(id))
            {
                TeamListing.Remove(id);
            }
        }

        public Team? Read(int id)
        {
            return TeamListing.ContainsKey(id) ? TeamListing[id] : null;
        }

        public Team Update(int id, Team team)
        {
            if (TeamListing.ContainsKey(id))
            {
                TeamListing[id] = team;
            }

            return team;
        }
    }
}
