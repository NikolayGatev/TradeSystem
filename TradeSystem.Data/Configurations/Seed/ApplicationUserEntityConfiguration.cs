using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(GenerateApplicationUsers());
        }

        private ApplicationUser[] GenerateApplicationUsers()
        {
            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

            var hasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser user;

            user = new ApplicationUser()
            {
                Id = Guid.Parse("dea12856-c198-4129-b3f3-b893d8395082"),
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com"
            };
            user.PasswordHash =
                hasher.HashPassword(user, "111111");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                UserName = "client@gmail.com",
                NormalizedUserName = "client@gmail.com",
                Email = "client@gmail.com",
                NormalizedEmail = "client@gmail.com"
            };
            user.PasswordHash =
                hasher.HashPassword(user, "111111");
            users.Add(user);

            return users.ToArray();
        }
    }
}
