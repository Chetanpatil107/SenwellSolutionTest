using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenwellSolutionTest.Model;
using SenwellSolutionTest.Repository.Interface;

namespace SenwellSolutionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAsyncRepository employeeAsync;
        public EmployeeController(IEmployeeAsyncRepository employeeAsync)
        {
            this.employeeAsync = employeeAsync; 
        }
        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var result = await employeeAsync.GetEmployeeById(Id);

                if (result != null)
                {
                    baseResponse.StatusMassage = "Employee record fetch successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);

                }
                else
                {
                    baseResponse.StatusMassage = $"Employee record not found with Id: {Id}...!";
                    baseResponse.StatusCode = StatusCodes.Status404NotFound;

                    return Ok(baseResponse);
                }
            }
            catch(Exception ex)
            {
                baseResponse.StatusMassage = ex.Message;
                baseResponse.StatusCode = StatusCodes.Status409Conflict;
                return Ok(baseResponse);
            }
        }
        [HttpGet("GetEmployeeByDepartmetnName")]
        public async Task<IActionResult> GetEmployeeByDepartmetnName(string DepartmentName)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var result = await employeeAsync.GetEmployeeByDepartmetnName(DepartmentName);
                if (result.Count() > 0)
                {
                    baseResponse.StatusMassage = "Employee records fetch successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);

                }
                else
                {
                    baseResponse.StatusMassage = $"No any record found...!";
                    baseResponse.StatusCode = StatusCodes.Status404NotFound;

                    return Ok(baseResponse);
                }
            }
            catch(Exception ex)
            {
                baseResponse.StatusMassage= ex.Message;
                baseResponse.StatusCode= StatusCodes.Status409Conflict; 
                return Ok(baseResponse);
            }
        }
        [HttpGet("GetEmployeeBySalaryOrder")]
        public async Task<IActionResult> GetEmployeeBySalaryOrder()
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var result = await employeeAsync.GetEmployeeBySalaryOrder();
                if (result.Count() > 0)
                {
                    baseResponse.StatusMassage = "Employee records fetch successfully...!";
                    baseResponse.StatusCode = StatusCodes.Status200OK;
                    baseResponse.ResponseData = result;
                    return Ok(baseResponse);

                }
                else
                {
                    baseResponse.StatusMassage = $"No any record found...!";
                    baseResponse.StatusCode = StatusCodes.Status404NotFound;

                    return Ok(baseResponse);
                }
            }
            catch(Exception ex)
            {
                baseResponse.StatusMassage=ex.Message;  
                baseResponse.StatusCode=StatusCodes.Status409Conflict;
                return Ok(baseResponse);
            }
        }
    }
}
