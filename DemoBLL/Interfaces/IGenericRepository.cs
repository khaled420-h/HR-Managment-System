﻿using DemoDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Interfaces
{
    public interface IGenericRepository<T> where T : ModelBase
    {

        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public IEnumerable<T> GetAll();
        public T Get(int id);


    }
}
