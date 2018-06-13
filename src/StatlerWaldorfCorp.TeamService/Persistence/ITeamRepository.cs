using System;
using System.Collections.Generic;
using StatlerWaldorfCorp.TeamService.Models;

namespace StatlerWaldorfCorp.TeamService.Persistence
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        Team GetTeam(Guid id);
        Team AddTeam(Team team);
        void DeleteTeam(Team team);
        Team UpdateTeam(Team team);
    }
}