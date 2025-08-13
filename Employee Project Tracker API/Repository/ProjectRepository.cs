using Employee_Project_Tracker_API.Interface;
using Employee_Project_Tracker_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Project_Tracker_API.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly EmployeeProjectTrackerContext _context;

        public ProjectRepository(EmployeeProjectTrackerContext context)
        {
            _context = context;
        }
        async Task<Project> IProjectRepository.Add(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        async Task<bool> IProjectRepository.Delete(int id)
        {
            var deletingProject = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (deletingProject == null)
            {
                return false;
            }
            _context.Projects.Remove(deletingProject);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

       

        async Task<Project> IProjectRepository.GetProjectByID(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p=>p.ProjectId == id);
        }

        async Task<Project> IProjectRepository.Update(int id, Project project)
        {
            var existingProject = await _context.Projects.FirstOrDefaultAsync(p=>p.ProjectId == id);
            if (existingProject == null)
                return null;

            existingProject.ProjectName = project.ProjectName;
            existingProject.ProjectCode = project.ProjectCode;
            existingProject.StartDate = project.StartDate;
            existingProject.EndDate = project.EndDate;
            existingProject.Budget = project.Budget;
            existingProject.Employees = project.Employees;

            await _context.SaveChangesAsync();
            return existingProject;
        }
    }
}
