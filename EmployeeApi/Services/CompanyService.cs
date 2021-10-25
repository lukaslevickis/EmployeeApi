using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeApi.DAL;
using EmployeeApi.DAL.Entities;
using EmployeeApi.DAL.Repositories;
using EmployeeApi.Dtos;

namespace EmployeeApi.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _companyRepository.GetByIDAsync(id);
        }

        public async Task CreateAsync(CompanyCreationDto company)
        {
            Company entity = _mapper.Map<Company>(company);
            await _companyRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _companyRepository.DeleteAsync(entity);
        }

        public async Task UpdateAsync(CompanyEditDto company)
        {
            Company entity = _mapper.Map<Company>(company);
            await _companyRepository.UpdateAsync(entity);
        }

        public async Task<List<Employee>> GetCompanyEmployeesAsync(int companyId)
        {
            return await _companyRepository.GetCompanyEmployeesAsync(companyId);
        }

        public async Task<int> GetCompanyEmployeeCountAsync(int companyId)
        {
            List<Employee> employees = await _companyRepository.GetCompanyEmployeesAsync(companyId);
            return employees.Count;
        }
    }
}
