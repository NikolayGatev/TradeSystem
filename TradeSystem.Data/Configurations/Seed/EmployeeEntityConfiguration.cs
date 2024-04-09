using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(GenerateAdminstrators());
        }

        private Employee[] GenerateAdminstrators()
        {
            ICollection<Employee> employees = new HashSet<Employee>();

            Employee employee;

            employee = new Employee()
            {
                Id = Guid.Parse("67524a1e-2595-440e-a6d2-103aaf179a08"),
                IsApproved = true,
                ApplicationUserId = "dea12856-c198-4129-b3f3-b893d8395082",
                FirstName = "Admin",
                LastName = "Administrator",
                PhoneNumber = "1234567890",
                DivisionId = 1,
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Id = Guid.Parse("4bcfd374-c252-4193-8bfe-5e84379984cf"),
                IsApproved = true,
                ApplicationUserId = "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb",
                FirstName = "Employee",
                LastName = "Employeev",
                PhoneNumber = "2234567890",
                DivisionId = 1,
            };
            employees.Add(employee);

            return employees.ToArray();
        }
    }
}
