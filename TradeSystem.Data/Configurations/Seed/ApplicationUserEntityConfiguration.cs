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
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com"
            };
            user.PasswordHash =
                hasher.HashPassword(user, "111111");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb",
                UserName = "employee@gmail.com",
                NormalizedUserName = "employee@gmail.com",
                Email = "employee@gmail.com",
                NormalizedEmail = "employee@gmail.com"
            };
            user.PasswordHash =
                hasher.HashPassword(user, "111111");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "individual@gmail.com",
                NormalizedUserName = "individual@gmail.com",
                Email = "individual@gmail.com",
                NormalizedEmail = "individual@gmail.com"
            };
            user.PasswordHash =
                hasher.HashPassword(user, "111111");
            users.Add(user);

            user = new ApplicationUser()
            {
                Id = "7586d7f6-e626-4e06-999e-7c977382c6de",
                UserName = "corporative@gmail.com",
                NormalizedUserName = "corporative@gmail.com",
                Email = "corporative@gmail.com",
                NormalizedEmail = "corporative@gmail.com"
            };
            user.PasswordHash =
                hasher.HashPassword(user, "111111");
            users.Add(user);

            return users.ToArray();
        }
    }
}
