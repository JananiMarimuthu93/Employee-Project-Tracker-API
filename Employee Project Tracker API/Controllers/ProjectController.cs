using Employee_Project_Tracker_API.IService;
using Employee_Project_Tracker_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Project_Tracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjects();
            return Ok(projects);
        }

        // GET: api/project/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByID(id);
            if (project == null)
                return NotFound();
            return Ok(project);
        }

        // POST: api/project
        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(Project project)
        {
            var createdProject = await _projectService.Add(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.ProjectId }, createdProject);
        }

        // PUT: api/project/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project project)
        {
            var updatedProject = await _projectService.Update(id, project);
            if (updatedProject == null)
                return NotFound();
            return Ok(updatedProject);
        }

        // DELETE: api/project/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var deleted = await _projectService.Delete(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
