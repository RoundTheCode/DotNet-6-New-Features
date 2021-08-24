
using System.Collections.Generic;

namespace RoundTheCode.DotNet6
{
    public interface ITeamService
    {
        Dictionary<int, Team> TeamListing { get; set; }

        Team Create(Team team);

        Team? Read(int id);

        Team Update(int id, Team team);

        void Delete(int id);
    }
}
