using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDAL.Model
{
    public  class Department:ModelBase
    {

        public string Name { get; set; }


        public string Code { get; set; }

        public DateTime DateofCreation { get; set; } = DateTime.Now;


        [InverseProperty(nameof(Employee.Department))]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
