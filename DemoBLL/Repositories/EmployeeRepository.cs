using DemoBLL.Interfaces;
using DemoDAL.Data.Contexts;
using DemoDAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(DemoMCVContext dbcontext) : base(dbcontext)
        {

        }

        public IQueryable<Employee> GetEmployeeByAddress(string address)
        {
            return _dbcontext.Employees.Where(E => E.Adresss.ToLower().Contains(address.ToLower()));
         
        }

        public IQueryable<Employee> GetEmployeeByName(string Name) 
        {
            return _dbcontext.Employees.Where(E => E.Name.ToLower().Contains(Name));
        }
    }
}
