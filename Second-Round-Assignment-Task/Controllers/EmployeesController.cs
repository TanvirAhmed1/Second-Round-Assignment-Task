using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Second_Round_Assignment_Task.DataModels;
using Second_Round_Assignment_Task.DomainModels;
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
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return Ok(_mapper.Map<List<EmployeeDto>>(employees));
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
            return Ok(_mapper.Map<EmployeeDto>(employee));
        }
        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeDto request)
        {
            var employee = await _employeeRepository.AddAsync(_mapper.Map<Employee>(request));
            return CreatedAtAction(nameof(GetEmployeeAsync), new { employeeId = employee.Id }, employee);
        }
        [HttpDelete]
        [Route("[controller]/{employeeId:int}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee != null)
            {   
                await _employeeRepository.RemoveAsync(employee);
                return Ok(_mapper.Map<EmployeeDto>(employee));
            }
            return NotFound();
        }
        [HttpPut]
        [Route("[controller]/{employeeId:int}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] int employeeId, [FromBody] EmployeeDto request)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee!=null)
            {
                var updatedEmployee = await _employeeRepository.UpdateEmployeeAsync(employeeId, _mapper.Map<Employee>(request));
                if (updatedEmployee != null)
                {
                    return Ok(_mapper.Map<EmployeeDto>(updatedEmployee));
                }
            }

            return NotFound();

        }
        [HttpPost]
        [Route("[controller]/Search")]
        public async Task<IActionResult> SearchEmployeeAsync([FromBody] EmployeeSearchDto request)
        {
            var employees = await _employeeRepository.GetByRequest(_mapper.Map<Employee>(request));
            return Ok(_mapper.Map<List<EmployeeDto>>(employees));
        }[HttpPost]

        [Route("[controller]/SearchWithPaging")]
        public async Task<IActionResult> SearchEmployeePagingAsync([FromBody] EmployeeSearchPagingDto request)
        {
            var employees = await _employeeRepository.GetByRequestPaging(request.PageSize, request.PageNumber ,_mapper.Map<Employee>(request));
            return Ok(_mapper.Map<List<EmployeeDto>>(employees));
        }
    }
}
