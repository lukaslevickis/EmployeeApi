using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeApi.DAL.Entities;

namespace EmployeeApi.DAL.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<List<Employee>> GetCompanyEmployeesAsync(int companyId);
    }
}
