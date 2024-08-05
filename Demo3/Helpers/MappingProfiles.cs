using AutoMapper;
using Demo3.ViewModels;
using DemoDAL.Model;

namespace Demo3.Helpers
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {

            CreateMap<EmployeeViewModel, Employee>().ReverseMap();


            CreateMap<DepartmentViewModel, Department>().ReverseMap();
        }

    }
}
