using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Second_Round_Assignment_Task.DataModels;
using Second_Round_Assignment_Task.Repositories;
using System;
using System.Collections.Generic;
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
        [Route("[controller]")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return Ok(employees);
        }
        [HttpGet]
        [Route("[controller]/{employeeId:int}"), ActionName("GetEmployeeAsync")]
        public async Task<IActionResult> GetEmployeeAsync([FromRoute] int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
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
        [HttpDelete]
        [Route("[controller]/{employeeId:int}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee != null)
            {   
                await _employeeRepository.RemoveAsync(employee);
                return Ok(employee);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("[controller]/{employeeId:int}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] int employeeId, [FromBody] Employee request)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee!=null)
            {
                var updatedEmployee = await _employeeRepository.UpdateEmployeeAsync(employeeId, request);
                if (updatedEmployee != null)
                {
                    return Ok(updatedEmployee);
                }
            }

            return NotFound();

        }
    }
}
