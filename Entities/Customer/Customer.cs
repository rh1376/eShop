using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Customer : IdentityUser<int>, IEntity
    {
        public Customer()
        {           
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }


        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
    }

    public class UserConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {           
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);

        }
    }  
}
