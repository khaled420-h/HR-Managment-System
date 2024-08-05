using DemoDAL.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Http;

namespace Demo3.ViewModels
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is REquired ")]
        [MinLength(5, ErrorMessage = "Min Length For The Name is 5 Chars ")]
        [MaxLength(50, ErrorMessage = "Max Length For The Name is 5 Chars ")]
        public string Name { get; set; }
        [Range(22, 30)]
        public int? Age { get; set; }

        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$"
            , ErrorMessage = "Address Must be Like 123-street-City-Country")]
        public string Adresss { get; set; }

        [DataType(DataType.Currency)]
        public Decimal Salary { get; set; }

        [Display(Name = "IS Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string Mail { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public String Phone { get; set; }

        [Display(Name = "Hiring Date")]
        public DateTime HireDate { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        public string ImageName { get; set; }

        [ForeignKey(nameof(Department))]
        public int? DepartmentId { get; set; }

        [InverseProperty(nameof(DemoDAL.Model.Department.Employees))]
        public virtual Department Department { get; set; }


    }
}
