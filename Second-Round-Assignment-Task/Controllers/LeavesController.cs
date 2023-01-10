using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Second_Round_Assignment_Task.DataModels;
using Second_Round_Assignment_Task.DomainModels;
using Second_Round_Assignment_Task.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Second_Round_Assignment_Task.Controllers
{
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly IMapper _mapper;
        public LeavesController(ILeaveRepository leaveRepository, IMapper mapper)
        {
            _leaveRepository = leaveRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllLeaves()
        {
            var leaves = await _leaveRepository.GetAllAsync();
            return Ok(_mapper.Map<List<LeaveDto>>(leaves));
        }
        [HttpGet]
        [Route("[controller]/EmployeeWiseLeave/{employeeId:int}")]
        public IActionResult GetByEmployeeLeaves([FromRoute] int employeeId)
        {
            var leaves = _leaveRepository.GetByEmployeeAsync(employeeId);
            return Ok(_mapper.Map<List<LeaveDto>>(leaves));
        }
        [HttpGet]
        [Route("[controller]/{leaveId:int}"), ActionName("GetLeaveAsync")]
        public async Task<IActionResult> GetLeaveAsync([FromRoute] int leaveId)
        {
            var leave = await _leaveRepository.GetByIdAsync(leaveId);
            if (leave == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<LeaveDto>(leave));
        }
        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddLeaveAsync([FromBody] LeaveDto request)
        {
            var leave = await _leaveRepository.AddAsync(_mapper.Map<Leave>(request));
            return CreatedAtAction(nameof(GetLeaveAsync), new { leaveId = leave.Id }, leave);
        }
        [HttpDelete]
        [Route("[controller]/{leaveId:int}")]
        public async Task<IActionResult> DeleteLeaveAsync([FromRoute] int leaveId)
        {
            var leave = await _leaveRepository.GetByIdAsync(leaveId);
            if (leave != null)
            {
                await _leaveRepository.RemoveAsync(leave);
                return Ok(_mapper.Map<LeaveDto>(leave));
            }
            return NotFound();
        }
        [HttpPut]
        [Route("[controller]/{leaveId:int}")]
        public async Task<IActionResult> UpdateLeaveAsync([FromRoute] int leaveId, [FromBody] LeaveUpdateDto request)
        {
            var leave = await _leaveRepository.GetByIdAsync(leaveId);
            if (leave != null)
            {
                var updatedLeave = await _leaveRepository.UpdateLeaveAsync(leaveId, _mapper.Map<Leave>(request));
                if (updatedLeave != null)
                {
                    return Ok(_mapper.Map<LeaveDto>(updatedLeave));
                }
            }

            return NotFound();

        }
    }
}
