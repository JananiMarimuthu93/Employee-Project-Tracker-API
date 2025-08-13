using Employee_Project_Tracker_API.Interface;
using Employee_Project_Tracker_API.Models;
using Employee_Project_Tracker_API.ServiceRepository;

namespace Employee_Project_Tracker_API.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        async Task<Employee> IEmployeeService.Add(Employee employee)
        {
           return await _repository.Add(employee);
        }

        async Task<bool> IEmployeeService.Delete(int id)
        {
            return await _repository.Delete(id);
        }

        async Task<IEnumerable<Employee>> IEmployeeService.GetAllEmployees()
        {
            return await _repository.GetAllEmployees();
        }

        async Task<Employee> IEmployeeService.GetEmployeeByID(int id)
        {
            return await _repository.GetEmployeeByID(id);
        }

        async Task<Employee> IEmployeeService.Update(int id, Employee employee)
        {
            return await _repository.Update(id, employee);
        }
    }
}
