using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeApi.DAL;
using EmployeeApi.DAL.Entities;
using EmployeeApi.Dtos;
using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private readonly UnitOfWork _unit;
        public EmployeeService(UnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _unit.EmployeesRepository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _unit.EmployeesRepository.GetByIDAsync(id);
        }

        public async Task CreateAsync(EmployeeCreationDto employee)
        {
            var entity = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Sex = (Sex)employee.Sex,
                CompanyId = employee.CompanyId
            };

            await _unit.EmployeesRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _unit.EmployeesRepository.DeleteAsync(entity);
        }

        public async Task UpdateAsync(EmployeeEditDto employee)
        {
            var entity = new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Sex = (Sex)employee.Sex,
                CompanyId = employee.CompanyId
            };

            await _unit.EmployeesRepository.UpdateAsync(entity);
        }
    }
}
