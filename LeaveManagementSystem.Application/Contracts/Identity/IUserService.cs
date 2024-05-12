using LeaveManagementSystem.Application.Models.Identity;

namespace LeaveManagementSystem.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(string userId);
    }
}
