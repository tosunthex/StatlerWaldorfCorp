using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using StatlerWaldorfCorp.TeamService.Models;
using StatlerWaldorfCorp.TeamService.Persistence;

namespace StatlerWaldorfCorp.TeamService.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController: Controller
    {
        private readonly ITeamRepository _repository;
        public TeamsController(ITeamRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual IActionResult GetAllTeams()
        {
            return this.Ok(_repository.GetTeams());
        }
        
        [HttpPost]
        public virtual IActionResult CreateTeam(Team team)
        {
            return this.Created("Ok",_repository.AddTeam(team));
        }
        
        [HttpGet("{id}")]
        public virtual IActionResult GetTeam(Guid id)
        {
            var team = _repository.GetTeam(id);
            if (team == null)
                return this.NotFound();
            
            return this.Ok(team);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult DeleteTeam(Guid id)
        {
            var team = _repository.GetTeam(id);
            if (team == null)
                return this.NotFound();
            
            _repository.DeleteTeam(team);
            return this.Ok(team);
        }
        
        [HttpPut("{id}")]
        public virtual IActionResult UpdateTeam([FromBody] Team team)
        {
            
            var t =  _repository.UpdateTeam(team);
            if (t == null)
                return this.NotFound();

            return this.Ok(t);
        }
    }
}