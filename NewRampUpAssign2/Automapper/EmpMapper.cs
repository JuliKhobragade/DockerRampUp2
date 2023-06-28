using AutoMapper;
using NewRampUpAssign2.Models;


namespace NewRampUpAssign2.Automapper
{
    public class EmpMapper:Profile
    {
        public EmpMapper()
        {
            CreateMap<Employee, EmpData>().ReverseMap();
        }
    }
}
