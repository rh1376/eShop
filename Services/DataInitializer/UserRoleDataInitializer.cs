using Data;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.DataInitializer
{
    public class UserRoleDataInitializer : IDataInitializer
    {        
        private readonly UserManager<User> _userManager;
        private readonly IRepository<UserRole> _userRolerepository;
        private readonly IRepository<Role> _RoleRepository;
        public UserRoleDataInitializer(UserManager<User> userManager, IRepository<Role> RoleRepository, IRepository<UserRole> userRolerepository)
        {            
            _userManager = userManager;
            _userRolerepository = userRolerepository;
            _RoleRepository = RoleRepository;
        }

        public void InitializeData()
        {
            var user = _userManager.Users.FirstOrDefault(c => c.UserName == "Admin");
            var userroles = _userRolerepository.TableNoTracking.Where(c => c.UserId == user.Id).Select(c => c.RoleId).ToList();
            var role = _RoleRepository.TableNoTracking.FirstOrDefault(c => c.Name == "Admin");
            if (user != null && !userroles.Contains(role.Id))
            {
                _userRolerepository.Add(new UserRole
                {
                    UserId = user.Id,
                    RoleId = role.Id
                });
            }

        }
    }
}
