using Employee_Project_Tracker_API.Models;

namespace Employee_Project_Tracker_API.Interface
{
    public interface IEmployeeRepository
    {
      Task<IEnumerable<Employee>> GetAllEmployees();
      Task<Employee> GetEmployeeByID(int id);
      Task<Employee> Add(Employee employee);
      Task<Employee> Update(int id, Employee employee);
      Task<bool> Delete(int id);
    }
}
