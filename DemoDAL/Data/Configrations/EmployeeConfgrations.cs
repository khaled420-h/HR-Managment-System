using DemoDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoDAL.Data.Configrations
{
    internal class EmployeeConfgrations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Salary).HasColumnType("decimal(18, 2)");

            builder.HasOne(D => D.Department).WithMany(E => E.Employees).OnDelete(DeleteBehavior.Cascade);

            builder.Property(E => E.Name).IsRequired(true).HasMaxLength(50);
;            //builder.Property(E)




        }
    }
}
