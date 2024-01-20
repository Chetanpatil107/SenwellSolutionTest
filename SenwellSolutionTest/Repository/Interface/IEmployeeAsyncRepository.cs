using SenwellSolutionTest.Model;

namespace SenwellSolutionTest.Repository.Interface
{
    public interface IEmployeeAsyncRepository
    {
        Task<Employee> GetEmployeeById(int Id);
        Task<List<Employee>> GetEmployeeByDepartmetnName(string DepartmentName);
        Task<List<Employee>> GetEmployeeBySalaryOrder();
    }
}
