using System;
using System.Threading.Tasks;
using EmployeeApi.DAL.Entities;
using EmployeeApi.DAL.Repositories;

namespace EmployeeApi.DAL
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        public GenericRepository<Company> companies { get; private set; }
        public GenericRepository<Employee> employees { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public GenericRepository<Company> CompanyRepository
        {
            get
            {
                if (this.companies == null)
                {
                    this.companies = new GenericRepository<Company>(_context);
                }

                return companies;
            }
        }

        public GenericRepository<Employee> EmployeesRepository
        {
            get
            {

                if (this.employees == null)
                {
                    this.employees = new GenericRepository<Employee>(_context);
                }
                return employees;
            }
        }
    }
}
