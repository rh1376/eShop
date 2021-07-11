using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class User : IdentityUser<int>, IEntity
    {
        public User()
        {           
        }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string CodeMeli { get; set; }

        public int age { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTimeOffset? LastLoginDate { get; set; }       
     
               
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {           
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.CodeMeli).IsRequired().HasMaxLength(15);
            builder.Property(p => p.age).IsRequired().HasMaxLength(5);
            builder.Property(p => p.LoginTime).IsRequired();

        }
    }  
}
