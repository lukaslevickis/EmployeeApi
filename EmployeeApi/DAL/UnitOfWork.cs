using System;
using System.Threading.Tasks;
using EmployeeApi.DAL.Entities;
using EmployeeApi.DAL.Repositories;

namespace EmployeeApi.DAL
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        public GenericRepository<Employee> _employeeRepository;
        private CompanyRepository _companyRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public CompanyRepository CompanyRepository
        {
            get
            {
                if (this._companyRepository == null)
                {
                    this._companyRepository = new CompanyRepository(_context);
                }

                return _companyRepository;
            }
        }

        public GenericRepository<Employee> EmployeesRepository
        {
            get
            {

                if (this._employeeRepository == null)
                {
                    this._employeeRepository = new GenericRepository<Employee>(_context);
                }
                return _employeeRepository;
            }
        }
    }
}
