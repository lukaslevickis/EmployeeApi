using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeApi.DAL;
using EmployeeApi.DAL.Entities;
using EmployeeApi.DAL.Repositories;
using EmployeeApi.Dtos;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IGenericRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIDAsync(id);
        }

        public async Task<Employee> CreateAsync(EmployeeCreationDto employee)
        {
            Employee entity = _mapper.Map<Employee>(employee);
            //entity.CompanyId = 3;
            return await _employeeRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(entity);
        }

        public async Task<Employee> UpdateAsync(EmployeeEditDto employee)
        {
            Employee entity = _mapper.Map<Employee>(employee);
            //entity.CompanyId = 3;
            return await _employeeRepository.UpdateAsync(entity);
        }

        public async Task<List<string>> GetAllFirstNamesAsync()
        {
            List<Employee> employees = await _employeeRepository.GetAllAsync();

            return employees.Select(x => x.FirstName).ToList();
        }
    }
}
