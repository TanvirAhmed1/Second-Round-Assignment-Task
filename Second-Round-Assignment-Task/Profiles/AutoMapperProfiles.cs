using AutoMapper;
using Second_Round_Assignment_Task.DataModels;
using Second_Round_Assignment_Task.DomainModels;

namespace Second_Round_Assignment_Task.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
