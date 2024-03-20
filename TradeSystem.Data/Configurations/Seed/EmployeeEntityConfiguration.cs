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
                ApplicationUserId = Guid.Parse("dea12856-c198-4129-b3f3-b893d8395082"),
                FirstName = "Admin",
                LastName = "Compaince",
                PhoneNumber = "1234567890",
                DivisionId = 1,
            };
            employees.Add(employee);
            return employees.ToArray();
        }
    }
}
