using DemoBLL.Interfaces;
using DemoDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoDAL.Data.Contexts;

namespace DemoBLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {

        public DepartmentRepository(DemoMCVContext dbcontext):base(dbcontext) //Clr Will Create Obj Of DbContext And Inject it in RunTime 
        {

        }


        //public int Add(Department department)
        //{
            
        //    _dbContext.Departments.Add(department);
        //    return  _dbContext.SaveChanges();
        //}

        //public int Delete(Department department)
        //{
        //    _dbContext.Departments.Remove(department);
        //    return _dbContext.SaveChanges(); 

        //}

        //public Department Get(int id)
        //{
        //    //var result =_dbContext.Departments.Local.Where(D=>D.Id == id).FirstOrDefault();
        //    //if (result == null)
        //    //result = _dbContext.Departments.Where(D => D.Id == id).FirstOrDefault();
        //    //return result;
        //    return _dbContext.Departments.Find(id);
        //}

        //public IEnumerable<Department> GetAll()
        //{
        //    return _dbContext.Departments.AsNoTracking().ToList();
        //}

        //public int Update(Department department)
        //{
        //    _dbContext.Departments.Update(department);
        //    return _dbContext.SaveChanges();
        //}
    }
}
