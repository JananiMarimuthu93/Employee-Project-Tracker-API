using Employee_Project_Tracker_API.Models;

namespace Employee_Project_Tracker_API.IService
{
    public interface IProjectService
    {
        public Task<IEnumerable<Project>> GetAllProjects();
        public Task<Project> GetProjectByID(int id);
        public Task<Project> Add(Project project);
        public Task<Project> Update(int id, Project project);
        public Task<bool> Delete(int id);
    }
}
