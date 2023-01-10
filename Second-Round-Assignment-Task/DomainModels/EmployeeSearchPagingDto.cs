namespace Second_Round_Assignment_Task.DomainModels
{
    public class EmployeeSearchPagingDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
