using Employee_Project_Tracker_API.Interface;
using Employee_Project_Tracker_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Project_Tracker_API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeProjectTrackerContext _context;

        public EmployeeRepository(EmployeeProjectTrackerContext context)
        {
            _context = context;
        }
         async Task<Employee> IEmployeeRepository.Add(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        async Task<bool> IEmployeeRepository.Delete(int id)
        {
            var deletingEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (deletingEmployee == null)
            {
                return false;
            }
             _context.Employees.Remove(deletingEmployee);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<IEnumerable<Employee>> IEmployeeRepository.GetAllEmployees()
        {
            return await _context.Employees.Include(e => e.Project).ToListAsync();
        }

        async Task<Employee> IEmployeeRepository.GetEmployeeByID(int id)
        {
            var employee=await _context.Employees.FirstOrDefaultAsync(e=>e.EmployeeId == id);
            return employee;
        }

        async Task<Employee> IEmployeeRepository.Update(int id, Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.EmployeeCode = employee.EmployeeCode;
            existingEmployee.FullName = employee.FullName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Designation = employee.Designation;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.ProjectId = employee.ProjectId;

            await _context.SaveChangesAsync();
            return existingEmployee;
        }
    }
}
