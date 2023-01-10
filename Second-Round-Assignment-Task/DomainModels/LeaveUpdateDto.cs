using System;

namespace Second_Round_Assignment_Task.DomainModels
{
    public class LeaveUpdateDto
    {
        public string LeaveType { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
