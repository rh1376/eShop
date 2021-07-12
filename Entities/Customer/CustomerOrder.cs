using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CustomerOrder : BaseEntity
    {
        public CustomerOrder()
        {

        }

        public int CustomerId { get; set; }
        public int OrderId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
    }

    public class CustomerOrderConfiguration : IEntityTypeConfiguration<CustomerOrder>
    {
        public void Configure(EntityTypeBuilder<CustomerOrder> builder)
        {
            builder.HasOne(p => p.Customer).WithMany(c => c.CustomerOrder).HasForeignKey(p => p.CustomerId);
            builder.HasOne(p => p.Order).WithMany(c => c.CustomerOrder).HasForeignKey(p => p.OrderId);
        }
    }
}
