using System;
using AutoMapper;
using EmployeeApi.DAL.Entities;
using EmployeeApi.Dtos;

namespace EmployeeApi.Profiles
{
    public class MainProfile: Profile
    {
        public MainProfile()
        {
            CreateMap<EmployeeCreationDto, Employee>();
            CreateMap<EmployeeEditDto, Employee>();
            CreateMap<CompanyCreationDto, Company>();
            CreateMap<CompanyEditDto, Company>();
        }
    }
}
