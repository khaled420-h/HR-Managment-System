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
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected readonly DemoMCVContext _dbcontext;
            
        public GenericRepository(DemoMCVContext dbcontext)  //Clr Will Create Obj Of DbContext And Inject it in RunTime
        {
            _dbcontext = dbcontext;
        }
        public void Add(T entity)
          => _dbcontext.Add(entity); // EF Core 3.1 Feature
          

        public void Delete(T entity)
          =>  _dbcontext.Remove(entity); // EF Core 3.1 Feature
           

        public T Get(int id)
        { 
            //return _dbcontext.Set<T>().Find(id); 
            return _dbcontext.Find<T>(id);    // EFCore 3.1 Feature

        }

        public IEnumerable<T> GetAll()
            =>  _dbcontext.Set<T>()/*.AsNoTracking()*/.ToList();
       
        public void Update(T entity)
         =>   _dbcontext.Update(entity); // EF Core 3.1 Feature

    }
}
