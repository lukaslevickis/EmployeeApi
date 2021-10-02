using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeApi.DAL;
using EmployeeApi.DAL.Entities;
using EmployeeApi.Dtos;

namespace EmployeeApi.Services
{
    public class CompanyService
    {
        private readonly UnitOfWork _unit;
        public CompanyService(UnitOfWork unit)
        {
            _unit = unit;
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
            var entity = new Company()
            {
                Name = company.Name
            };

            await _unit.CompanyRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _unit.CompanyRepository.DeleteAsync(entity);
        }

        public async Task UpdateAsync(CompanyEditDto company)
        {
            var entity = new Company()
            {
                Id = company.Id,
                Name = company.Name
            };

            await _unit.CompanyRepository.UpdateAsync(entity);
        }
    }
}
