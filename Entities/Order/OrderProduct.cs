using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderProduct : BaseEntity
    {
        public OrderProduct()
        {

        }

        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }

    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasOne(p => p.Product).WithMany(c => c.OrderProduct).HasForeignKey(p => p.ProductId);
            builder.HasOne(p => p.Order).WithMany(c => c.OrderProduct).HasForeignKey(p => p.OrderId);
        }
    }
}
