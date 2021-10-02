using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeApi.DAL;
using EmployeeApi.DAL.Entities;
using EmployeeApi.Dtos;

namespace EmployeeApi.Services
{
    public class CompanyService
    {
        private readonly UnitOfWork _unit;
        private readonly IMapper _mapper;

        public CompanyService(UnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _unit.CompanyRepository.GetAllAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _unit.CompanyRepository.GetByIDAsync(id);
        }

        public async Task CreateAsync(CompanyCreationDto company)
        {
            Company entity = _mapper.Map<Company>(company);
            await _unit.CompanyRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _unit.CompanyRepository.DeleteAsync(entity);
        }

        public async Task UpdateAsync(CompanyEditDto company)
        {
            Company entity = _mapper.Map<Company>(company);
            await _unit.CompanyRepository.UpdateAsync(entity);
        }

        public async Task<List<Employee>> GetCompanyEmployeesAsync(int companyId)
        {
            return await _unit.CompanyRepository.GetCompanyEmployeesAsync(companyId);
        }

        public async Task<int> GetCompanyEmployeeCountAsync(int companyId)
        {
            List<Employee> employees = await _unit.CompanyRepository.GetCompanyEmployeesAsync(companyId);
            return employees.Count;
        }
    }
}
