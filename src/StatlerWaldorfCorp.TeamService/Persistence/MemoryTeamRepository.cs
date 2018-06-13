using System;
using System.Collections.Generic;
using System.Linq;
using StatlerWaldorfCorp.TeamService.Models;

namespace StatlerWaldorfCorp.TeamService.Persistence
{
    public class MemoryTeamRepository:ITeamRepository
    {
        protected static ICollection<Team> Teams;
        
        public MemoryTeamRepository()
        {
            //Teams = null;
            Teams = new List<Team>();
        }

        public MemoryTeamRepository(ICollection<Team> teams)
        {
            Teams = teams;
        }
        public IEnumerable<Team> GetTeams()
        {
            return Teams;
        }

        public Team GetTeam(Guid id)
        {
            return Teams.SingleOrDefault(t => t.Id == id);
        }

        public Team AddTeam(Team team)
        {
            Teams.Add(team);
            return team;
        }

        public void DeleteTeam(Team team)
        {
            Teams.Remove(team);
        }

        public Team UpdateTeam(Team team)
        {
            var t = this.GetTeam(team.Id);
            if (t == null)
                return null;

            t.Name = team.Name;
            t.Members = t.Members;

            return t;
        }
    }
}