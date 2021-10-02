using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.DAL.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetCompanyEmployeesAsync(int companyId)
        {
            return await _context.Employees.Where(x => x.CompanyId == companyId).ToListAsync();
        }
    }
}
