using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDAL.Model
{
    public class Employee:ModelBase
    {
       

        
        public string Name { get; set; }
      
        public int? Age { get; set; }

        public string Adresss { get; set; }

        public Decimal  Salary { get; set; }

        public bool  IsActive { get; set; }

        public string  Mail { get; set; }

        public String Phone { get; set; }

        public DateTime HireDate { get; set; }

        public string ImageName { get; set; }

        public bool  ISDeleted { get; set; } = false;

        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Department))]
       public  int? DepartmentId { get; set; }

        [InverseProperty(nameof(Model.Department.Employees))]
        public virtual Department Department { get; set; }

    }
}
