using Data.Contracts;
using Data.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.DataInitializer
{
    public class RoleDataInitializer : IDataInitializer
    {
        private readonly IRepository<Role> _repository;
        public RoleDataInitializer(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public void InitializeData()
        {
            if (!_repository.TableNoTracking.Any(p => p.Name == "Admin"))
            {
                _repository.Add(new Role
                {
                    Name = "Admin",
                    Description = "ادمین",
                });
            }
        }
    }
}
