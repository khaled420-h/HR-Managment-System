using DemoDAL.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Demo3.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name Is Required ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Code Is Required ")]
        public string Code { get; set; }

        [Display(Name = "Date Of Creation")]
        public DateTime DateofCreation { get; set; }


        [InverseProperty(nameof(Employee.Department))]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    }
}
