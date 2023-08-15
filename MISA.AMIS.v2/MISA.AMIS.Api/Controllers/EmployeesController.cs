using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Models;
using MISA.AMIS.Infrastructure;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : MISABasesController<Employee>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeRepository employeeRepository,
            IEmployeeService employeeService) : base(employeeRepository, employeeService)
        {
            this.employeeRepository = employeeRepository;
            this.employeeService = employeeService;
        }



        [HttpGet("Filter")]
        public IActionResult GetPaging(int pageIndex, int pageSize, string? filter)
        {
            try
            {
                var res = employeeRepository.GetPaging(pageIndex, pageSize, filter);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }



        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                var data = employeeRepository.GetNewEmployeeCode();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("DeleteMultiple")]
        public IActionResult DeleteMultiple(string EmployeeId)
        {
            try
            {
                var data = employeeRepository.DeleteMultiple(EmployeeId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

    }
}
