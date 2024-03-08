using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class AdministratorEntityConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.HasData(GenerateAdminstrators());
        }

        private Administrator[] GenerateAdminstrators()
        {
            ICollection<Administrator> administrators = new HashSet<Administrator>();

            Administrator administrator;

            administrator = new Administrator()
            {
                Id = Guid.Parse("67524a1e-2595-440e-a6d2-103aaf179a08"),
                ApplicationUserId = Guid.Parse("dea12856-c198-4129-b3f3-b893d8395082"),
                FirstName = "Admin",
                LastName = "Compaince",
                PhoneNumber = "1234567890",
                DivisionId = 1,
            };
            administrators.Add(administrator);
            return administrators.ToArray();
        }
    }
}
