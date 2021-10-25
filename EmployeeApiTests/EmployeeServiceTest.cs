using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeApi.DAL;
using EmployeeApi.DAL.Entities;
using EmployeeApi.DAL.Repositories;
using EmployeeApi.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace EmployeeApiTests
{
    public class EmployeeServiceTest
    {
        EmployeeService _employeeService;

        [Fact]
        public async void GetAllFirstNamesAsync()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee
            {
                Id = 1,
                FirstName = "Lukas",
                LastName = "Le",
                Sex = (EmployeeApi.Models.Sex)1,
                CompanyId = 1
            });

            Mock<IGenericRepository<Employee>> mockRepository = new Mock<IGenericRepository<Employee>>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            mockRepository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(employees));
            _employeeService = new EmployeeService(mockRepository.Object, mockMapper.Object);
            await _employeeService.GetAllFirstNamesAsync();
            _employeeService.Should().NotBeNull();
        }
    }
}
