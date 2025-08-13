using Employee_Project_Tracker_API.Interface;
using Employee_Project_Tracker_API.IService;
using Employee_Project_Tracker_API.Models;

namespace Employee_Project_Tracker_API.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
           _repository=repository;
        }
        async Task<Project> IProjectService.Add(Project project)
        {
            return await _repository.Add(project);
        }

        async Task<bool> IProjectService.Delete(int id)
        {
            return await _repository.Delete(id);
        }

        async Task<IEnumerable<Project>> IProjectService.GetAllProjects()
        {
            return await _repository.GetAllProjects();
        }

        async Task<Project> IProjectService.GetProjectByID(int id)
        {
            return await _repository.GetProjectByID(id);
        }

        async Task<Project> IProjectService.Update(int id, Project project)
        {
            return await _repository.Update(id, project);
        }
    }
}
