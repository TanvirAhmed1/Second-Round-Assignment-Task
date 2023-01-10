using System;

namespace Second_Round_Assignment_Task.DomainModels
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
    }
}
