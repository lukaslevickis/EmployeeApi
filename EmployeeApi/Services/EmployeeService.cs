using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeApi.DAL;
using EmployeeApi.DAL.Entities;
using EmployeeApi.Dtos;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private readonly UnitOfWork _unit;
        private readonly IMapper _mapper;

        public EmployeeService(UnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
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
            Employee entity = _mapper.Map<Employee>(employee);
            await _unit.EmployeesRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _unit.EmployeesRepository.DeleteAsync(entity);
        }

        public async Task UpdateAsync(EmployeeEditDto employee)
        {
            Employee entity = _mapper.Map<Employee>(employee);
            await _unit.EmployeesRepository.UpdateAsync(entity);
        }
    }
}
