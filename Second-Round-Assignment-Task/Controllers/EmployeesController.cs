using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Second_Round_Assignment_Task.DataModels;
using Second_Round_Assignment_Task.Repositories;
using System;
using System.Threading.Tasks;

namespace Second_Round_Assignment_Task.Controllers
{

    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        [Route("[controller]/{employeeId:int}"), ActionName("GetEmployeeAsync")]
        public async Task<IActionResult> GetEmployeeAsync([FromRoute] int employeeId)
        {
            var employee = await _employeeRepository.GetById(employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] Employee request)
        {
            var student = await _employeeRepository.AddAsync(request);
            //return CreatedAtAction(nameof(GetStudentAsync), new { studentId = student.Id }, mapper.Map<StudentDto>(student));
            return Ok();
        }
    }
}
