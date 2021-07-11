using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace Services.DataInitializer
{
    public class UserDataInitializer : IDataInitializer
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;

        public UserDataInitializer(IUserRepository userRepository, UserManager<User> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;

        }

        public void InitializeData()
        {
            if (!userRepository.TableNoTracking.Any(p => p.UserName == "Admin"))
            {
                var user = new User
                {
                    Name = "Admin",
                    LastName = "Admin",
                    CodeMeli = "AdminAdmin",
                    PhoneNumber = "AdminAdmin1",
                    UserName = "Admin",
                    Email = "admin@site.com",
                    EmailConfirmed = true,
                    NormalizedEmail = userManager.NormalizeEmail("admin@site.com"),
                    NormalizedUserName = userManager.NormalizeName("Admin"),
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "12345678");

                userRepository.Add(user);
            }
        }
    }
}
