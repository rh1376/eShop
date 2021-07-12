using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderDetails : BaseEntity
    {
        public OrderDetails()
        {

        }

        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }


    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Total).IsRequired();

            builder.HasOne(p => p.Order).WithOne(c => c.OrderDetails).HasForeignKey<OrderDetails>(p => p.OrderId);        
        }
    }
}
