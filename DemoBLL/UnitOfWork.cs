using DemoBLL.Interfaces;
using DemoBLL.Repositories;
using DemoDAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DemoMCVContext _dbcontext;

        public IDepartmentRepository DepartmentRepository { get; set ; }
        public IEmployeeRepository EmployeeRepository { get ; set ; }


        public UnitOfWork(DemoMCVContext demoMCVContext) // Clr Will Create Obj Of Db Context And Inject it Here 
        {
            _dbcontext = demoMCVContext;
            DepartmentRepository=new DepartmentRepository(_dbcontext);
            EmployeeRepository=new EmployeeRepository(_dbcontext);

        }


        public int Complete()
        {
           return _dbcontext.SaveChanges();
        }



        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
