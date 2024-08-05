using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        public IDepartmentRepository DepartmentRepository { get; set; }

        public IEmployeeRepository EmployeeRepository { get; set; }

        int Complete();



    }
}
