using Dapper;
using SenwellSolutionTest.Context;
using SenwellSolutionTest.Model;
using SenwellSolutionTest.Repository.Interface;

namespace SenwellSolutionTest.Repository
{
    public class EmployeeAsyncRepository:IEmployeeAsyncRepository
    {
        private readonly DapperContext _dapperContext;
        public EmployeeAsyncRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
           
        }

        public async Task<List<Employee>> GetEmployeeByDepartmetnName(string DepartmentName)
        {
            using(var connection=_dapperContext.CreateConnection())
            {
                var query = "Select employee_id, first_name, last_name, department, Address, hire_date, dob, joiningDate, salary From tblEmployee where department=@department";
                var employee=await connection.QueryAsync<Employee>(query, new { department =DepartmentName});
                return employee.ToList();
            }
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var query = "Select employee_id, first_name, last_name, department, Address, hire_date, dob, joiningDate, salary From tblEmployee where employee_id=@Id";
                var employee = await connection.QueryFirstOrDefaultAsync< Employee > (query, new { Id = Id });
                return employee;
            }
        }

        public async Task<List<Employee>> GetEmployeeBySalaryOrder()
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                var query = "Select employee_id, first_name, last_name, department, Address, hire_date, dob, joiningDate, salary From tblEmployee";
                var employee = await connection.QueryAsync<Employee>(query);
                return employee.ToList();
            }
        }
    }
}
