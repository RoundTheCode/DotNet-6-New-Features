using Microsoft.AspNetCore.Mvc;

namespace RoundTheCode.DotNet6
{
    [Route("team")]
    public class TeamController : Controller
    {
        protected readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            return Json(_teamService.Create(team));
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            return Json(_teamService.Read(id));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Team team)
        {
            return Json(_teamService.Update(id, team));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teamService.Delete(id);

            return Json(new { Success = true });
        }
    }
}
